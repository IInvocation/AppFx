using FluiTec.AppFx.DataProtection.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace FluiTec.AppFx.DataProtection.Dynamic
{
    /// <summary>   A data protection extension. </summary>
    public static class DataProtectionExtension
    {
        /// <summary>An IServiceCollection extension method that configure data protection data service.</summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="migrate">          (Optional) True to migrate. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureDataProtectionDataService(this IServiceCollection services, IConfigurationRoot configuration, bool migrate = true)
        {
            var provider = new DataProtectionDataProvider(configuration.GetConfiguration<DataProtectionOptions>());
            services.AddScoped(p => provider.GetDataService(configuration));

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
