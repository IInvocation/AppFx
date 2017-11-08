using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.AspNetCore.Examples.Simple
{
	/// <summary>	A startup. </summary>
	/// <remarks>
	///     1: Startup - used to initialize configuration
	///     2: ConfigureServices - loads all required services
	///     3: Configure - actual pipeline using the services
	/// </remarks>
	public class Startup
    {
		#region Properties

	    /// <summary>	Gets the configuration. </summary>
	    /// <value>	The configuration. </value>
	    public IConfigurationRoot Configuration { get; }

	    /// <summary>	Gets the environment. </summary>
	    /// <value>	The environment. </value>
	    public IHostingEnvironment Environment { get; }

		#endregion

		#region AspNetCore

		/// <summary>	Constructor. </summary>
		/// <param name="environment">	The environment. </param>
		public Startup(IHostingEnvironment environment)
	    {
		    var builder = new ConfigurationBuilder()
			    .SetBasePath(environment.ContentRootPath)
			    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: false)
			    .AddJsonFile(path: "appsettings.secret.json", optional: true, reloadOnChange: false)
			    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: false);

		    builder.AddEnvironmentVariables();
		    Configuration = builder.Build();
		    Environment = environment;
	    }

	    /// <summary>	Configure services. </summary>
	    /// <param name="services">	The services. </param>
	    public void ConfigureServices(IServiceCollection services)
	    {
			var connectionString = Configuration[key: "Dapper:ConnectionString"];
		    var apiOnly = Configuration[key: "Api:ApiOnlyPath"];

			services
				.ConfigureErrorHandling(Configuration)
				.ConfigureMailService(Configuration, Environment)
				.ConfigureAppFxIdentity(Configuration)
				.ConfigureIdentityForAppFxIdentity(Configuration, apiOnly)
				.ConfigureLocalization(Configuration)
				.ConfigureStatusCodeHandler(Configuration)
				.ConfigureStaticFiles(Configuration)
				.ConfigureMvc(Configuration);
		}

		/// <summary>	Configures. </summary>
		/// <param name="app">			  	The application. </param>
		/// <param name="environment">			  	The environment. </param>
		/// <param name="loggerFactory">  	The logger factory. </param>
		/// <param name="applicationLifetime">	  	The application lifetime. </param>
		/// <param name="serviceProvider">	The service provider. </param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment environment, ILoggerFactory loggerFactory,
		    IApplicationLifetime applicationLifetime, IServiceProvider serviceProvider)
		{
			app
				.UseLogging(environment, applicationLifetime, Configuration, loggerFactory)
				.UseErrorHandling(environment)
				.UseDevelopmentExtension(environment)
				.UseStaticFiles(Configuration)
				.UseLocalization(Configuration)
				.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod())
				.UseStatusCodeHandler(Configuration)
				.UseMvcWithApi(Configuration);
		}

		#endregion
	}
}
