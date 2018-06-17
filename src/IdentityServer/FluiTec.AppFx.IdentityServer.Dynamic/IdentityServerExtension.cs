using FluiTec.AppFx.IdentityServer.Dynamic;
using FluiTec.AppFx.IdentityServer.Dynamic.Configuration;
using FluiTec.AppFx.Options;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>	An identity extension. </summary>
    public static class IdentityServerExtension
    {
        /// <summary>An IServiceCollection extension method that configure identity.</summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <param name="migrate">          (Optional) True to migrate. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureIdentityServerDataService(this IServiceCollection services,
            IConfigurationRoot configuration, bool migrate = true)
        {
            var provider = new IdentityServerDataProvider(configuration.GetConfiguration<IdentityServerOptions>());
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