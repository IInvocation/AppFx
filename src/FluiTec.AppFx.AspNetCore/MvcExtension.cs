using System;
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
		    var mvc = services.AddMvc()
			    .AddJsonOptions(options =>
			    {
				    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
				    configureJson?.Invoke(options);
			    })
			    .AddViewLocalization(options =>
			    {
				    configureLocalization?.Invoke(options);
			    })
			    .AddDataAnnotationsLocalization(options =>
			    {
				    configureDataLocalization?.Invoke(options);
			    });

			configureMvc?.Invoke(new MvcOptions(mvc));

		    return services;
	    }
	}
}
