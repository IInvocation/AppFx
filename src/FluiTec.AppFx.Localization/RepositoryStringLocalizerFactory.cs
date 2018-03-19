using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.Localization
{
    /// <summary>A repository string localizer factory.</summary>
    public class RepositoryStringLocalizerFactory : IStringLocalizerFactory
    {
        /// <summary>The data service.</summary>
        private readonly ILocalizationDataService _dataService;

        /// <summary>The cache.</summary>
        private readonly ConcurrentDictionary<string, RepositoryStringCache> _cache = new ConcurrentDictionary<string, RepositoryStringCache>();

        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public RepositoryStringLocalizerFactory(ILocalizationDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>Creates an <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" /> using
        /// the <see cref="T:System.Reflection.Assembly" /> and
        /// <see cref="P:System.Type.FullName" /> of the specified <see cref="T:System.Type" />.</summary>
        /// <param name="resourceSource">   The <see cref="T:System.Type" />. </param>
        /// <returns>The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.</returns>
        public IStringLocalizer Create(Type resourceSource)
        {
            return Create(resourceSource.FullName, string.Empty);
        }

        /// <summary>Creates an <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.</summary>
        /// <param name="baseName"> The base name of the resource to load strings from. </param>
        /// <param name="location"> The location to load resources from. </param>
        /// <returns>The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizer" />.</returns>
        public IStringLocalizer Create(string baseName, string location)
        {
            if (!_cache.ContainsKey(baseName))
                _cache.TryAdd(baseName, new RepositoryStringCache(_dataService, baseName));
            var stringCache = _cache[baseName];
            return new RepositoryStringLocalizer(stringCache);
        }
    }
}