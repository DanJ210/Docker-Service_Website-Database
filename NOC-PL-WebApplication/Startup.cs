﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NOCPLWebApplication.Models;
using NOCPLWebApplication.Models.SeedData;

namespace NOC_PL_WebApplication {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<ProductLocationContext>();

            services.AddTransient<ProductServerSeedData>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ProductServerSeedData seeder) {
            loggerFactory.AddConsole();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(config => {
            config.MapRoute(
                name: "Default",
                template: "{Controller}/{Action}/{id?}",
                defaults: new { controller = "App", action = "Index" }
                );
            config.MapRoute(
                name: "Tables",
                template: "{Controller}/{Action}/{id?}",
                defaults: new { controller = "TableDataVMs", action = "Index" }
                );
            config.MapRoute(
                name: "TableDataVM",
                template:  "{Controller}/{Action}/{id?}/{server?}"
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
