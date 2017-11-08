using System;
using System.Globalization;
using System.Linq;
using FluiTec.AppFx.AspNetCore.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>	A localization extension. </summary>
	public static class LocalizationExtension
	{
		/// <summary>	Options for controlling the operation. </summary>
		private static CultureOptions _options;

		/// <summary>	An IServiceCollection extension method that configure localization. </summary>
		/// <param name="services">			The services to act on. </param>
		/// <param name="configuration">	The configuration. </param>
		/// <param name="configure">		The configure. </param>
		/// <returns>	An IServiceCollection. </returns>
		public static IServiceCollection ConfigureLocalization(this IServiceCollection services,
			IConfigurationRoot configuration, Action<CultureOptions> configure = null)
		{
			// parse options
			_options = configuration.GetConfiguration<CultureOptions>();

			// let user apply changes
			configure?.Invoke(_options);

			// register options
			services.AddSingleton(_options);

			// configure localization
			services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = _options.SupportedCultures.Select(e => new CultureInfo(e)).ToList();
				options.DefaultRequestCulture = new RequestCulture(_options.DefaultCulture);
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
			});

			services.AddLocalization(options => options.ResourcesPath = _options.ResourcesPath);

			return services;
		}

		/// <summary>	An IApplicationBuilder extension method that use localization. </summary>
		/// <param name="app">				The app to act on. </param>
		/// <param name="configuration">	The configuration. </param>
		/// <returns>	An IApplicationBuilder. </returns>
		public static IApplicationBuilder UseLocalization(this IApplicationBuilder app, IConfigurationRoot configuration)
		{
			var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(options.Value);

			return app;
		}
	}
}