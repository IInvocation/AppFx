using FluiTec.AppFx.DataProtection.Dynamic;
using FluiTec.AppFx.DataProtection.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>   A data protection extension. </summary>
    public static class DataProtectionExtension
    {
        /// <summary>
        ///     An IServiceCollection extension method that configure data protection data service.
        /// </summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <returns>   An IServiceCollection. </returns>
        public static IServiceCollection ConfigureDataProtectionDataService(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var provider = new DataProtectionDataProvider(configuration.GetConfiguration<DataProtectionOptions>());
            services.AddScoped(p => provider.GetDataService(configuration));
            return services;
        }
    }
}
