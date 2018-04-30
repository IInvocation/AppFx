using FluiTec.AppFx.Authorization.Activity.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Authorization.Activity.Dynamic
{
    /// <summary>An activity authorization extension.</summary>
    public static class ActivityAuthorizationExtension
    {
        /// <summary>
        ///     An IServiceCollection extension method that configure application effects identity
        ///     server.
        /// </summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureAppFxAuthorizationData(this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            var provider =
                new ActivityAuthorizationDataProvider(configuration.GetConfiguration<ActivityAuthorizationOptions>());
            services.AddScoped(p => provider.GetDataService(configuration));
            return services;
        }
    }
}