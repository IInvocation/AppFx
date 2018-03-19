using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FluiTec.AppFx.Localization
{
    /// <summary>A repository string cache.</summary>
    public class RepositoryStringCache
    {
        private readonly ILocalizationDataService _dataService;
        private readonly string _resourceName;
        private readonly ConcurrentDictionary<string, IEnumerable<KeyValuePair<string, string>>> _cache = new ConcurrentDictionary<string, IEnumerable<KeyValuePair<string, string>>>();

        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        /// <param name="resourceName"> Name of the resource. </param>
        public RepositoryStringCache(ILocalizationDataService dataService, string resourceName)
        {
            _dataService = dataService;
            _resourceName = resourceName;
        }

        /// <summary>Gets a translation.</summary>
        /// <param name="language"> The language. </param>
        /// <param name="key">      The key. </param>
        /// <returns>The translation.</returns>
        public string GetTranslation(string language, string key)
        {
            if (!_cache.ContainsKey(language))
                _cache.TryAdd(language, FetchTranslations(language));
            var result = _cache[language].SingleOrDefault(kv => kv.Key == key);
            return result.Value;
        }

        /// <summary>Gets the translations in this collection.</summary>
        /// <param name="language"> The language. </param>
        /// <returns>An enumerator that allows foreach to be used to process the translations in this
        /// collection.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetTranslations(string language)
        {
            if (!_cache.ContainsKey(language))
                _cache.TryAdd(language, FetchTranslations(language));
            return _cache[language];
        }

        /// <summary>Fetches the translations in this collection.</summary>
        /// <param name="language"> The language. </param>
        /// <returns>An enumerator that allows foreach to be used to process the translations in this
        /// collection.</returns>
        private IEnumerable<KeyValuePair<string, string>> FetchTranslations(string language)
        {
            using (var uow = _dataService.StartUnitOfWork())
            {
                var resources = uow.ResourceRepository.GetByName(_resourceName).ToList();
                var translations = uow.TranslationRepository.ByResources(resources, language);

                return translations.Select(t => new KeyValuePair<string, string>(resources.Single(r => r.Id == t.ResourceId).Key, t.Value));
            }
        }
    }
}