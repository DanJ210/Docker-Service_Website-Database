/*
 * OnSolve
 * Author: Daniel Jackson
 * Dialer Front End
 * Created: 03/22/2017
 * Last Edit: 09/22/2017
 * Description: Startup configuration for the web application.
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace NocWebUtilityApp
{
	public class Startup
	{
		IConfigurationRoot _config;
		public Startup(IHostingEnvironment env)
		{
			var levelSwitch = new LoggingLevelSwitch();
			levelSwitch.MinimumLevel = LogEventLevel.Debug;

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
			//.AddEnvironmentVariables(); Use production environment variables when deployed
			_config = builder.Build();

			Log.Logger = new LoggerConfiguration()
			.MinimumLevel.ControlledBy(levelSwitch)
			.Enrich.FromLogContext()
			.WriteTo.LiterateConsole()
			.WriteTo.RollingFile("logs\\myapp-{Date}.txt")
			.CreateLogger();
		}

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My Api", Version = "V1" });
			});

			var connectionString = _config["connectionStrings:dockerLocalLinuxVMConnectionString"];
			services.AddDbContext<ProductLocationContext>(options => options.UseSqlServer(connectionString));

			services.AddIdentity<NocUser, IdentityRole>()
				.AddEntityFrameworkStores<ProductLocationContext>();

			services.AddTransient<ProductServerSeedData>();

			services.AddScoped<IProductLocationRepository, ProductLocationRepository>();

			services.AddMvc();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory,
			IApplicationLifetime appLifetime,
			ProductServerSeedData seeder)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

			}
			else
			{
				app.UseExceptionHandler("/TableDataVMs/Error");
			}
			loggerFactory.AddSerilog();

			app.UseIdentity();
			// Ensures that any logs are written to file before app completely stops.
			appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

			app.UseStaticFiles();

			app.UseMvc(config =>
			{
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
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			// Seeds database with initial data if database is new.
			seeder.EnsureSeedData().Wait();
		}
	}
}
