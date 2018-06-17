using FluiTec.AppFx.Identity.Dynamic;
using FluiTec.AppFx.Identity.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>	An identity extension. </summary>
    public static class IdentityExtension
    {
        /// <summary>An IServiceCollection extension method that configure identity.</summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="migrate">          (Optional) True to migrate. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureIdentityDataService(this IServiceCollection services,
            IConfigurationRoot configuration, bool migrate = true)
        {
            var provider = new IdentityDataProvider(configuration.GetConfiguration<IdentityOptions>());
            services.AddSingleton(p => provider.GetDataService(configuration));

            if (migrate)
            {
                var dataService = provider.GetDataService(configuration);
                if (dataService.CanMigrate())
                    dataService.Migrate();
            }

            return services;
        }
    }
}