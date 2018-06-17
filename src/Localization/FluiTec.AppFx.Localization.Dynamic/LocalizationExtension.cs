using FluiTec.AppFx.Localization.Dynamic;
using FluiTec.AppFx.Localization.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>	An identity extension. </summary>
    public static class LocalizationExtension
    {
        /// <summary>An IServiceCollection extension method that configure identity.</summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="migrate">          (Optional) True to migrate. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureLocalizationDataService(this IServiceCollection services,
            IConfigurationRoot configuration, bool migrate = true)
        {
            var provider = new LocalizationDataProvider(configuration.GetConfiguration<LocalizationOptions>());
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