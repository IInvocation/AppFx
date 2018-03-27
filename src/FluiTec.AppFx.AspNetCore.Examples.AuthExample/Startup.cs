﻿using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample
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

        /// <summary>Gets the environment.</summary>
        /// <value>The environment.</value>
        public IHostingEnvironment Environment { get; }

        #endregion

        #region AspNetCore

        /// <summary>Constructor.</summary>
        /// <param name="environment">  . </param>
        /// <remarks>Adds configuration from json-Files and environment-variables.</remarks>
        public Startup(IHostingEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.secret.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>Configure services.</summary>
        /// <param name="services">     The services. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureErrorHandling(Configuration);
            services.ConfigureIdentity(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureIdentityServer(Configuration);
            services.ConfigureMvc(Configuration);
            services.ConfigureLocalization(Configuration);
            services.ConfigureMailService(Configuration, Environment);
            services.ConfigureStatusCodeHandler(Configuration);
            services.ConfigureStaticFiles(Configuration);
        }

        /// <summary>	Configures. </summary>
        /// <param name="app">			  	The application. </param>
        /// <param name="loggerFactory">  	The logger factory. </param>
        /// <param name="appLifetime">	  	The application lifetime. </param>
        /// <param name="serviceProvider">	The service provider. </param>
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime, IServiceProvider serviceProvider)
        {
            app.ApplicationServices.GetService<TelemetryConfiguration>().DisableTelemetry = true;

            app.UseLogging(Environment, appLifetime, Configuration, loggerFactory);
            app.UseErrorHandling(Environment);
            app.UseDevelopmentExtension(Environment);
            app.UseStaticFiles(Configuration, Environment);
            app.UseIdentityServer(Configuration);
            app.UseLocalization(Configuration);
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseStatusCodeHandler(Configuration);
            app.UseMvcWithApi(Configuration);
        }

        #endregion
    }
}
