using FluiTec.AppFx.Mail;
using FluiTec.AppFx.Mail.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorLight;

namespace FluiTec.AppFx.AspNetCore
{
    /// <summary>	A mail service extension. </summary>
    public static class MailServiceExtension
    {
        /// <summary>	Configure mail service. </summary>
        /// <param name="services">			The services. </param>
        /// <param name="environment">  	The environment. </param>
        /// <param name="configuration">	The configuration. </param>
        /// <returns>	An IServiceCollection. </returns>
        public static IServiceCollection ConfigureMailService(this IServiceCollection services, IConfigurationRoot configuration, IHostingEnvironment environment)
        {
            services.AddSingleton(configuration.GetConfiguration<MailServiceOptions>());
            services.AddRazorLightSelf(environment, "MailViews");
            services.AddScoped<ITemplatingMailService, MailKitTemplatingMailService>();

            return services;
        }

        /// <summary>   An IServiceCollection extension method that adds a razor light self. </summary>
        /// <param name="services">     The services. </param>
        /// <param name="environment">  The environment. </param>
        /// <param name="root">         The root. </param>
        private static void AddRazorLightSelf(this IServiceCollection services, IHostingEnvironment environment, string root)
        {
            services.AddSingleton<IRazorLightEngine>(f => new EngineFactory()
                .ForFileSystem(System.IO.Path.Combine(environment.ContentRootPath, root)));
        }
    }
}
