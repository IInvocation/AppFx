using System;
using System.Net;
using System.Threading.Tasks;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Dynamic;
using FluiTec.AppFx.Identity.Dynamic.Configuration;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Localization;
using FluiTec.AppFx.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>	An identity extension. </summary>
    public static class IdentityExtension
    {
	    /// <summary>	An IServiceCollection extension method that configure identity. </summary>
	    /// <param name="services">			The services to act on. </param>
	    /// <param name="configuration">	The configuration. </param>
	    /// <returns>	An IServiceCollection. </returns>
	    public static IServiceCollection ConfigureAppFxIdentity(this IServiceCollection services,
		    IConfigurationRoot configuration)
	    {
			var provider = new IdentityDataProvider(configuration.GetConfiguration<FluiTec.AppFx.Identity.Dynamic.Configuration.IdentityOptions>());
		    services.AddScoped(p => provider.GetDataService(configuration));
		    return services;
	    }

	    /// <summary>
	    /// An IServiceCollection extension method that configure identity for application effects
	    /// identity.
	    /// </summary>
	    ///
	    /// <param name="services">			The services to act on. </param>
	    /// <param name="configuration">	The configuration. </param>
	    /// <param name="apiOnlyPath">  	Full pathname of the API only file. </param>
	    ///
	    /// <returns>	An IServiceCollection. </returns>

	    public static IServiceCollection ConfigureIdentityForAppFxIdentity(this IServiceCollection services,
		    IConfigurationRoot configuration, string apiOnlyPath)
	    {
		    // configure aspnet-identity
		    services.AddIdentity<IdentityUserEntity, IdentityRoleEntity>(config =>
			    {
				    config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ öäüÖÄÜ ß 12345678";
				    config.SignIn.RequireConfirmedEmail = true;
				    config.Lockout.AllowedForNewUsers = true;
				    config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(value: 5);
			    })
			    .AddErrorDescriber<MultiLanguageIdentityErrorDescriber>()
			    .AddDefaultTokenProviders();
		    services.AddIdentityStores();

		    // configure cookies
		    services.ConfigureApplicationCookie(cOptions =>
		    {
			    cOptions.Events = new CookieAuthenticationEvents
			    {
				    // disable redirect to login for api-users
				    OnRedirectToLogin = context =>
				    {
					    if (context.Request.Path.StartsWithSegments(apiOnlyPath) &&
					        context.Response.StatusCode == (int)HttpStatusCode.OK)
						    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
					    else
						    context.Response.Redirect(context.RedirectUri);

					    return Task.CompletedTask;
				    }
			    };
		    });

		    return services;
	    }
    }
}
