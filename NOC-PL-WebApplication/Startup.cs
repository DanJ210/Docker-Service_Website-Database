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
using Serilog;

namespace NOC_PL_WebApplication { 
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env) {
            Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.Enrich.FromLogContext()
            .WriteTo.LiterateConsole()
            .WriteTo.RollingFile("logs\\myapp-{Date}.txt")
            .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services) {

            var connectionString = "Server=(localdb)\\MSSQLLocalDb;Database=PLTablesData;Trusted_Connection=true;MultipleActiveResultSets=true;";
            services.AddDbContext<ProductLocationContext>(options => options.UseSqlServer(connectionString));

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
            // Ensures that any logs are written to file before app completely stops.
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            app.UseStaticFiles();

            app.UseMvc(config => {
            config.MapRoute(
                name: "Default",
                template: "{Controller}/{Action}/{id?}",
                defaults: new { controller = "TableDataVMs", action = "Index" }
                );
            config.MapRoute(
                name: "Tables",
                template: "{Controller}/{Action}/{id?}",
                defaults: new { controller = "TableDataVMs", action = "Index" }
                );
            config.MapRoute(
                name: "TableDataVM",
                template:  "{Controller}/{Action}/{id?}/{serverId?}"
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
