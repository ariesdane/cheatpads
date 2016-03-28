using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

namespace AspNet5SQLite
{

    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
           
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Add Cors support to the service
            //services.AddCors();

            //var policy = new Microsoft.AspNet.Cors.Infrastructure.CorsPolicy();

            //policy.Headers.Add("*");
            //policy.Methods.Add("*");
            //policy.Origins.Add("*");
            //policy.SupportsCredentials = true;
            //
            //services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

            //services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            //app.UseExceptionHandler("/Home/Error");

            //app.UseCors("corsGlobalPolicy");

            app.UseStaticFiles();
           // app.UseMvc(routes =>
           // {
           //     routes.MapRoute(
           //         name: "default",
           //         template: "{controller=Home}/{action=Index}/{id?}");
           // });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
