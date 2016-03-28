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

using CheatPads.Api.Model;
using CheatPads.Api.Repositories;
using CheatPads.Data;

namespace CheatPads.Api
{

    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["Data:Development:SqliteConnectionString"];

            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<ResourceContext>(options => options.UseSqlite(connection));

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DataContext>(options => {
                    options.UseSqlServer(Configuration["Data:Development:SqlServerConnectionString"]);
                });

            //Add Cors support to the service
            services.AddCors();

            var policy = new Microsoft.AspNet.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

            services.AddMvc();
            services.AddScoped<IRepository<UserEvent>, UserEventRepository>();
            services.AddScoped<IRepository<UserDocument>, UserDocumentRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();
            app.UseExceptionHandler("/Home/Error");
            app.UseCors("corsGlobalPolicy");
            app.UseStaticFiles();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseJwtBearerAuthentication(options =>
            {
                options.Authority = "https://localhost:44345";
                options.Audience = "https://localhost:44345/resources";
                options.AutomaticAuthenticate = true;
            });

            app.UseMiddleware<RequiredScopesMiddleware>(new List<string> { "CheatPads.Api" });
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
