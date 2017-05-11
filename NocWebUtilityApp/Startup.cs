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
using NocWebUtilityApp.Models;
using NocWebUtilityApp.Models.SeedData;
using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Serilog.Core;
using Serilog.Events;
using NocWebUtilityApp.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace NocWebUtilityApp {
    public class Startup {
        public static IConfigurationRoot Configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env) {
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = LogEventLevel.Debug;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                //.AddEnvironmentVariables(); Use production environment variables when deployed
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .Enrich.FromLogContext()
            .WriteTo.LiterateConsole()
            .WriteTo.RollingFile("logs\\myapp-{Date}.txt")
            .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services) {

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "My Api", Version = "V1" });
            });
            //services.ConfigureSwaggerGen();
            //services.AddSingleton(loggingSwitch);
            var connectionString = Configuration["connectionStrings:nocProductServerDBConnectionString"];
            services.AddDbContext<ProductLocationContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<NocUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductLocationContext>();

            services.AddTransient<ProductServerSeedData>();

            services.AddScoped<IProductLocationRepository, ProductLocationRepository>();

            //services.AddLogging(); May not be needed after introducing SeriLog.
            

            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime,
            ProductServerSeedData seeder) {

            //loggerFactory.AddConsole();
            //loggerFactory.AddApplicationInsights();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //loggingSwitch.MinimumLevel = LogEventLevel.Debug;
                //loggerFactory.AddDebug(LogLevel.Information);
                
            } else {
                app.UseExceptionHandler("/TableDataVMs/Error");
                //loggingSwitch.MinimumLevel = LogEventLevel.Error;
                //loggerFactory.AddDebug(LogLevel.Error);
            }
            loggerFactory.AddSerilog();

            app.UseIdentity();
            // Ensures that any logs are written to file before app completely stops.
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            app.UseStaticFiles();

            app.UseMvc(config => {

                //config.MapRoute(
                //    name: "TableDataVM",
                //    template: "",
                //    defaults: new { controller = "TableDataVMs", action = "TablesView"}
                //);
                
                config.MapRoute(
                    name: "SaveServerToProduct",
                    template: "SaveSelectedServer",
                    defaults: new { controller = "TableDataVMs", action = "SaveSelectedServer" }
                    );
                config.MapRoute(
                    name: "Default",
                    template: "{Controller}/{Action}/{id?}",
                    defaults: new { controller = "TableDataVMs", action = "TablesPage1" }
                    );
                //config.MapRoute(
                //    name: "Login",
                //    template: "{Controller}/{Action}",
                //    defaults: new { controller = "Account", action = "Login" }
                //    );
                //config.MapRoute(
                //    name: "Error",
                //    template: "TableDataVMs/Error",
                //    defaults: new { controller = "TableDataVMs", action = "Error" }
                //    );
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // The call to seed data, .Wait() trick to fake async

            seeder.EnsureSeedData().Wait();

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
