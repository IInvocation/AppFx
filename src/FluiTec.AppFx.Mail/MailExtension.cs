using System;
using FluiTec.AppFx.Mail;
using FluiTec.AppFx.Mail.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RazorLight;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class MailExtension
    {
	    /// <summary>	Options for controlling the operation. </summary>
	    private static MailServiceOptions _options;

	    /// <summary>	Configure mail service. </summary>
	    /// <param name="services">			The services. </param>
	    /// <param name="configuration">	The configuration. </param>
	    /// <param name="environment">  	The environment. </param>
	    /// <param name="configure">		The configure. </param>
	    /// <returns>	An IServiceCollection. </returns>
	    public static IServiceCollection ConfigureMailService(this IServiceCollection services,
		    IConfigurationRoot configuration, IHostingEnvironment environment, Action<MailServiceOptions> configure)
	    {
			// parse options
		    _options = configuration.GetConfiguration<MailServiceOptions>();

			// let user apply changes
		    configure(_options);

			// register
		    services.AddSingleton(_options);
		    services.AddRazorLightSelf(environment, _options.TemplateRoot);
		    services.AddScoped<ITemplatingMailService, MailKitTemplatingMailService>();

		    return services;
	    }

	    /// <summary>	An IServiceCollection extension method that adds a razor light self. </summary>
	    /// <param name="services">   	The services. </param>
	    /// <param name="environment">	The environment. </param>
	    /// <param name="root">		  	The root. </param>
	    private static void AddRazorLightSelf(this IServiceCollection services, IHostingEnvironment environment, string root)
	    {
		    services.AddSingleton<IRazorLightEngine>(f => new EngineFactory()
			    .ForFileSystem(System.IO.Path.Combine(environment.ContentRootPath, root)));
	    }
	}
}
