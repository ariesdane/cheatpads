using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace CheatPads.Api
{
    using CheatPads.Api.Security;
    using CheatPads.Api.Entity;

    public class Startup
    {
        public IConfigurationRoot _config { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ApplicationBasePath)
                .AddJsonFile("config.json");

            _config = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // data services
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApiDbContext>(options => {
                    options.UseSqlServer(_config["Data:Development:SqlServerConnectionString"]);
                });

            services.AddScoped<Entity.Stores.ProductStore>();
            services.AddScoped<Entity.Stores.CategoryStore>();
            services.AddScoped<Entity.Stores.ColorStore>();
            services.AddScoped<Entity.Stores.OrderStore>();

            // hosting          
            services.AddCors(x => {
                var policy = new Microsoft.AspNet.Cors.Infrastructure.CorsPolicy();

                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;

                x.AddPolicy("corsGlobalPolicy", policy);
            });

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            });

            // security
            services.Configure<SecurityConfig>(_config.GetSection("Security"));
            services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddSingleton<IAuthorizationHandler, TrustedWebClientHandler>();

            services.AddAuthorization(options =>
                options.AddPolicy("TrustedClients", p => p.AddRequirements(new TrustedWebClientRequirement()))
            );    
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            // data services
            if (hostingEnvironment.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetService<ApiDbContext>().EnsureDbExists();
                }
                app.UseDeveloperExceptionPage();
            }

            // logging & auditiong
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
        
            // hosting
            app.UseIISPlatformHandler();
            app.UseCors("corsGlobalPolicy");
            app.UseStaticFiles();


            // security
            SecurityConfig securityConfig = app.ApplicationServices.GetService<IOptions<SecurityConfig>>().Value;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();
            
            app.UseJwtBearerAuthentication(options =>
            {
                options.Authority = securityConfig.Authority;
                options.Audience = securityConfig.Audience;
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
            });

            app.UseMiddleware<RequiredScopesMiddleware>(securityConfig);

            // routing
            app.UseMvcWithDefaultRoute();    
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
