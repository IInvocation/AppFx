using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.DataProtection;

namespace FluiTec.AppFx.DataProtection
{
    /// <summary>	A service collection extension. </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     An IServiceCollection extension method that adds an application effects data
        ///     protection.
        /// </summary>
        /// <param name="services"> The services to act on. </param>
        /// <returns>   An IServiceCollection. </returns>
        public static IServiceCollection AddAppFxDataProtection(this IServiceCollection services)
        {
            services.AddScoped<IXmlRepository, DataProtectionKeyRepository>();
            var built = services.BuildServiceProvider();
            services.AddDataProtection().AddKeyManagementOptions(options => options.XmlRepository = built.GetService<IXmlRepository>());

            return services;
        }
    }
}
