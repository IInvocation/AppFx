using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using MvcOptions = FluiTec.AppFx.AspNetCore.Configuration.MvcOptions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>	A MVC extension. </summary>
    /// <remarks>
    /// This class configures MVC, enables Newtonsoft.Json
    /// and adds localization-capatibilities for views and DataAnnotations
    /// </remarks>
    public static class MvcExtension
    {
	    /// <summary>	An IServiceCollection extension method that configure MVC. </summary>
	    ///
	    /// <param name="services">						The services to act on. </param>
	    /// <param name="configuration">				The configuration. </param>
	    /// <param name="configureJson">				The configure JSON. </param>
	    /// <param name="configureLocalization">		The configure localization. </param>
	    /// <param name="configureDataLocalization">	The configure data localization. </param>
	    /// <param name="configureMvc">					The configure MVC. </param>
	    /// <returns>	An IServiceCollection. </returns>
	    public static IServiceCollection ConfigureMvc(this IServiceCollection services, IConfigurationRoot configuration, 
			Action<MvcJsonOptions> configureJson = null, 
			Action<LocalizationOptions> configureLocalization = null, 
			Action<MvcDataAnnotationsLocalizationOptions> configureDataLocalization = null,
			Action<MvcOptions> configureMvc = null)
	    {
		    var mvc = services.AddMvc();
            mvc.AddJsonOptions(options =>
			    {
				    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
				    configureJson?.Invoke(options);
			    });
            if (configureLocalization == null)
                mvc.AddViewLocalization();
            else
                mvc.AddViewLocalization(configureLocalization.Invoke);
            if (configureDataLocalization == null)
	            mvc.AddDataAnnotationsLocalization();
	        else
	            mvc.AddDataAnnotationsLocalization(configureDataLocalization.Invoke);

			configureMvc?.Invoke(new MvcOptions(mvc));

		    return services;
	    }

	    /// <summary>	An IApplicationBuilder extension method that use MVC. </summary>
	    /// <param name="app">				The app to act on. </param>
	    /// <param name="configuration">	The configuration. </param>
	    /// <returns>	An IApplicationBuilder. </returns>
	    public static IApplicationBuilder UseMvc(this IApplicationBuilder app, IConfigurationRoot configuration)
	    {
		    app.UseMvc(routes =>
		    {
			    routes.MapRoute(
				    "default",
				    "{controller=Home}/{action=Index}/{id?}");
		    });
		    return app;
	    }

	    /// <summary>	An IApplicationBuilder extension method that use MVC. </summary>
	    /// <param name="app">				The app to act on. </param>
	    /// <param name="configuration">	The configuration. </param>
	    /// <returns>	An IApplicationBuilder. </returns>
	    public static IApplicationBuilder UseMvcWithApi(this IApplicationBuilder app, IConfigurationRoot configuration)
	    {
		    app.UseMvc(routes =>
		    {
			    routes.MapRoute(
				    "default",
				    "{controller=Home}/{action=Index}/{id?}");

			    routes.MapRoute(
				    "api",
				    "api/[controller]");
		    });
		    return app;
	    }

	    /// <summary>	An IApplicationBuilder extension method that use MVC. </summary>
	    /// <param name="app">				The app to act on. </param>
	    /// <param name="configuration">	The configuration. </param>
	    /// <returns>	An IApplicationBuilder. </returns>
	    public static IApplicationBuilder UseMvcApiOnly(this IApplicationBuilder app, IConfigurationRoot configuration)
	    {
		    app.UseMvc(routes =>
		    {
			    routes.MapRoute(
				    "api",
				    "api/[controller]");
		    });
		    return app;
	    }
	}
}
