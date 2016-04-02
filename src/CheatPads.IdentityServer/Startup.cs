using Microsoft.AspNet.Builder;
using System.Security.Cryptography.X509Certificates;

using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.Identity;

using CheatPads.IdentityServer.Identity;
using IdentityServer4.Core.Services;
using IdentityServer4.Core.Validation;

namespace CheatPads.IdentityServer
{
    using System.IO;

    using IdentityServer4.Core.Configuration;

    using CheatPads.IdentityServer.Configuration;
    using CheatPads.IdentityServer.UI;
    using CheatPads.IdentityServer.UI.Login;

    using Microsoft.Extensions.Logging;

    public class Startup
    {
        //private readonly IApplicationEnvironment _environment;
        public IConfigurationRoot Configuration { get; set; }
        public string ApplicationBasePath { get; set; }

        public Startup(IApplicationEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ApplicationBasePath)
                .AddJsonFile("config.json");


            Configuration = builder.Build();
            ApplicationBasePath = environment.ApplicationBasePath;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var cert = new X509Certificate2(Path.Combine(ApplicationBasePath, "server.pfx"), "");

            var builder = services.AddIdentityServer(options =>
            {
                options.SigningCertificate = cert;
                options.RequireSsl = false;
            });

            builder.AddInMemoryClients(Clients.Get());
            builder.AddInMemoryScopes(Scopes.Get());
            //builder.AddInMemoryUsers(Users.Get()); 

            // AspNet Identity (instead in memory users)
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IdentityDbContext>(options => {
                    options.UseSqlServer(Configuration["Data:Development:IdentityConnectionString"]);
                });

            services.AddIdentity<AppUser, AppRole>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddUserManager<IdentityUserManager>()
            .AddRoleManager<IdentityRoleManager>();

            // IdentityServer Service Hooks to Use Identity Server
            services.AddTransient<IResourceOwnerPasswordValidator, IdentityPasswordValidator>();
            services.AddTransient<IProfileService, IdentityProfileService>();

            // Identity Server UI
            services
                .AddMvc()
                .AddRazorOptions(razor =>
                {
                    razor.ViewLocationExpanders.Add(new CustomViewLocationExpander());
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Verbose);
            loggerFactory.AddDebug(LogLevel.Verbose);

            if (hostingEnvironment.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetService<IdentityDbContext>().EnsureDbExists();
                }
                app.UseDeveloperExceptionPage();
            }
          
            app.UseIISPlatformHandler();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
       
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}