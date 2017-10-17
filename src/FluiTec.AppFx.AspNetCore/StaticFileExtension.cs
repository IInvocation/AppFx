﻿using System;
using FluiTec.AppFx.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using StaticFileOptions = FluiTec.AppFx.AspNetCore.Configuration.StaticFileOptions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>	A static file extension. </summary>
	public static class StaticFileExtension
	{
		/// <summary>	Options for controlling the operation. </summary>
		private static StaticFileOptions _options;

		/// <summary>	Options for controlling the file. </summary>
		private static AspNetCore.Builder.StaticFileOptions _fileOptions;

		/// <summary>	An IServiceCollection extension method that configure static files. </summary>
		/// <param name="services">			The services to act on. </param>
		/// <param name="configuration">	The configuration. </param>
		/// <param name="configure">		The configure. </param>
		/// <returns>	An IServiceCollection. </returns>
		public static IServiceCollection ConfigureStaticFiles(this IServiceCollection services,
			IConfigurationRoot configuration, Action<StaticFileOptions> configure, Action<AspNetCore.Builder.StaticFileOptions> configureFiles)
		{
			// parse options
			_options = configuration.GetConfiguration<StaticFileOptions>();

			// let user apply changes
			configure(_options);

			// create file-options
			_fileOptions = new AspNetCore.Builder.StaticFileOptions();

			// let user apply changes
			configureFiles(_fileOptions);

			// register options
			services.AddSingleton(_options);

			return services;
		}

		/// <summary>	An IApplicationBuilder extension method that use static files. </summary>
		/// <param name="app">				The app to act on. </param>
		/// <param name="configuration">	The configuration. </param>
		/// <returns>	An IApplicationBuilder. </returns>
		public static IApplicationBuilder UseStaticFiles(this IApplicationBuilder app, IConfigurationRoot configuration)
		{
			app.UseStaticFiles(new AspNetCore.Builder.StaticFileOptions
			{
				OnPrepareResponse = ctx =>
				{
					if (_options.EnableClientCaching)
					{
						ctx.Context.Response.Headers[HeaderNames.CacheControl] =
							"public,max-age=" + _options.CacheDuration;
					}
				}
			});

			return app;
		}
	}
}