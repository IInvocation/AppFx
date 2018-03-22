using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DbLocalizationProvider;
using DbLocalizationProvider.Cache;
using DbLocalizationProvider.Internal;
using DbLocalizationProvider.Queries;
using DbLocalizationProvider.Sync;

namespace FluiTec.AppFx.Localization.Sync
{
    /// <summary>   A resource synchronizer. </summary>
    public class ResourceSynchronizer
    {
        /// <summary>   The data service. </summary>
        private readonly ILocalizationDataService _dataService;

        /// <summary>   Constructor. </summary>
        /// <param name="dataService">  The data service. </param>
        public ResourceSynchronizer(ILocalizationDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        /// <summary>   Discover and register. </summary>
        public void DiscoverAndRegister()
        {
            if (!ConfigurationContext.Current.DiscoverAndRegisterResources)
                return;

            var discoveredTypes = TypeDiscoveryHelper.GetTypes(t => t.GetCustomAttribute<LocalizedResourceAttribute>() != null,
                t => t.GetCustomAttribute<LocalizedModelAttribute>() != null);

            var discoveredResources = discoveredTypes[0];
            var discoveredModels = discoveredTypes[1];
            var foreignResources = ConfigurationContext.Current.ForeignResources;
            if (foreignResources != null && foreignResources.Any())
            {
                discoveredResources.AddRange(foreignResources.Select(x => x.ResourceType));
            }

            ResetSyncStatus();
            var allResources = new GetAllResources.Query().Execute();

            Parallel.Invoke(() => RegisterDiscoveredResources(discoveredResources, allResources),
                () => RegisterDiscoveredResources(discoveredModels, allResources));

            if (ConfigurationContext.Current.PopulateCacheOnStartup)
                PopulateCache();
        }

        /// <summary>   Resets the synchronise status. </summary>
        private void ResetSyncStatus()
        {
            using (var uow = _dataService.StartUnitOfWork())
            {
                uow.ResourceRepository.ResetSyncStatus();
                uow.Commit();
            }
        }

        /// <summary>   Populate cache. </summary>
        private void PopulateCache()
        {
            new ClearCache.Command().Execute();
            var allResources = new GetAllResources.Query().Execute();

            foreach (var resource in allResources)
            {
                var key = CacheKeyHelper.BuildKey(resource.ResourceKey);
                ConfigurationContext.Current.CacheManager.Insert(key, resource);
            }
        }

        private void RegisterDiscoveredResources(IEnumerable<Type> types, IEnumerable<LocalizationResource> allResources)
        {
            var helper = new TypeDiscoveryHelper();
            var properties = types.SelectMany(type => helper.ScanResources(type)).DistinctBy(r => r.Key);

            // split work queue by 400 resources each
            var groupedProperties = properties.SplitByCount(400);

            Parallel.ForEach(groupedProperties, group =>
                {
                    var refactoredResources = group.Where(r => !string.IsNullOrEmpty(r.OldResourceKey));
                });
        }
    }
}