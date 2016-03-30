using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

using CheatPads.Api.Data;
using CheatPads.Api.Data.Models;
using CheatPads.Api.Data.Repositories;

namespace CheatPads.Api
{

    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ApplicationBasePath)
                .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // data services
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApiDbContext>(options => {
                    options.UseSqlServer(Configuration["Data:Development:SqlServerConnectionString"]);
                });

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<ProductRepository>();

            //services.AddScoped<IRepository<UserDocument>, UserDocumentRepository>();

            // hosting
            var policy = new Microsoft.AspNet.Cors.Infrastructure.CorsPolicy();

            services.AddCors();    
            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));
            services.AddMvc();

            // security
           
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
            app.UseExceptionHandler("/Home/Error");
            app.UseCors("corsGlobalPolicy");
            app.UseStaticFiles();

            // security
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseJwtBearerAuthentication(options =>
            {
                options.Authority = "https://localhost:44345";
                options.Audience = "https://localhost:44345/resources";
                options.AutomaticAuthenticate = true;
            });

            app.UseMiddleware<RequiredScopesMiddleware>(new List<string> { "CheatPads.Api" });

            // routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });          
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
