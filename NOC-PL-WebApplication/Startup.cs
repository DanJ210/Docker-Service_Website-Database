using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NOCPLWebApplication.Models;
using NOCPLWebApplication.Models.SeedData;
using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NOC_PL_WebApplication {
    public class Startup {
        public static IConfigurationRoot Configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                //.AddEnvironmentVariables(); Use production environment variables when deployed
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.LiterateConsole()
            .WriteTo.RollingFile("logs\\myapp-{Date}.txt")
            .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services) {

            var connectionString = Configuration["connectionStrings:nocProductServerDBConnectionString"];
            services.AddDbContext<ProductLocationContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<NocUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductLocationContext>();
            services.AddTransient<ProductServerSeedData>();

            //services.AddLogging(); May not be needed
            

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime,
            ProductServerSeedData seeder) {

            //loggerFactory.AddConsole();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //loggerFactory.AddDebug(LogLevel.Information);
                loggerFactory.AddSerilog();
            } else {
                //loggerFactory.AddDebug(LogLevel.Error);
            }

            app.UseIdentity();
            // Ensures that any logs are written to file before app completely stops.
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            app.UseStaticFiles();

            app.UseMvc(config => {

                //config.MapRoute(
                //    name: "Login",
                //    template: "{Controller}/{Action}",
                //    defaults: new { controller = "Account", action = "Login" }
                //    );
                config.MapRoute(
                    name: "TableDataVM",
                    template: "{Controller}/{Action}/{id?}/{serverId?}"
                    );
                config.MapRoute(
                    name: "Default",
                    template: "{Controller}/{Action}/{id?}",
                    defaults: new { controller = "TableDataVMs", action = "Index" }
                    );
                
                config.MapRoute(
                    name: "Home/Error",
                    template: "Home/Error"
                    );
            });

            // The call to seed data, .Wait() trick to fake async
           
            seeder.EnsureSeedData().Wait();

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
