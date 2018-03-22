using System;
using DbLocalizationProvider;
using DbLocalizationProvider.Cache;
using DbLocalizationProvider.Queries;
using FluiTec.AppFx.Localization.Cache;
using FluiTec.AppFx.Localization.Handlers;
using FluiTec.AppFx.Localization.MetadataProviders;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.Localization
{
    /// <summary>   A service collection extensions. </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     An IServiceCollection extension method that adds a database localization provider to
        ///     'setup'.
        /// </summary>
        /// <param name="services"> The services to act on. </param>
        /// <param name="setup">    (Optional) The setup. </param>
        /// <returns>   An IServiceCollection. </returns>
        public static IServiceCollection AddDbLocalizationProvider(this IServiceCollection services, Action<ConfigurationContext> setup = null)
        {
            ConfigurationContext.Current.TypeFactory.ForQuery<GetTranslation.Query>().SetHandler<GetTranslationHandler>();
            ConfigurationContext.Current.TypeFactory.ForQuery<GetAllResources.Query>().SetHandler<GetAllResourcesHandler>();
            ConfigurationContext.Current.TypeFactory.ForQuery<DetermineDefaultCulture.Query>().SetHandler<DetermineDefaultCulture.Handler>();

            //ConfigurationContext.Current.TypeFactory.ForQuery<AvailableLanguages.Query>().SetHandler<AvailableLanguages.Handler>();
            //ConfigurationContext.Current.TypeFactory.ForQuery<GetAllTranslations.Query>().SetHandler<GetAllTranslations.Handler>();
            //ConfigurationContext.Current.TypeFactory.ForCommand<CreateNewResource.Command>().SetHandler<CreateNewResource.Handler>();
            //ConfigurationContext.Current.TypeFactory.ForCommand<DeleteResource.Command>().SetHandler<DeleteResource.Handler>();
            //ConfigurationContext.Current.TypeFactory.ForCommand<CreateOrUpdateTranslation.Command>().SetHandler<CreateOrUpdateTranslation.Handler>();

            ConfigurationContext.Current.TypeFactory.ForCommand<ClearCache.Command>().SetHandler<ClearCacheHandler>();

            // check if there's a registered cache - if not - add one
            var provider = services.BuildServiceProvider();
            var cache = provider.GetService<IMemoryCache>();
            if (cache != null)
                ConfigurationContext.Current.CacheManager = new InMemoryCacheManager(cache);

            // run custom configuration setup (if any)
            setup?.Invoke(ConfigurationContext.Current);

            // setup model metadata providers
            if (ConfigurationContext.Current.ModelMetadataProviders.ReplaceProviders)
                services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(_ =>
                {
                    _.ModelMetadataDetailsProviders.Add(new LocalizedDisplayMetadataProvider());
                    _.ModelValidatorProviders.Add(new LocalizedValidationMetadataProvider());
                });

            services.AddSingleton<IStringLocalizerFactory, DbStringLocalizerFactory>();
            services.AddSingleton(_ => LocalizationProvider.Current);

            return services;
        }
    }
}