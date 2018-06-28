using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   A caching JSON api. </summary>
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    public abstract class CachingJsonApi<TModel> : JsonApi<TModel> where TModel : class
    {
        /// <summary>   The default cache expiration seconds. </summary>
        private readonly int _defaultCacheExpirationSeconds = 3600;

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="service">  The service. </param>
        /// <param name="subPath">  Full pathname of the sub file. </param>
        /// <param name="cache">    The cache. </param>
        protected CachingJsonApi(IWebService service, string subPath, IMemoryCache cache) : base(service, subPath)
        {
            CacheExpiration = TimeSpan.FromSeconds(_defaultCacheExpirationSeconds);
            Cache = cache;
        }

        /// <summary>   Gets or sets the cache expiration. </summary>
        /// <value> The cache expiration. </value>
        public TimeSpan CacheExpiration { get; set; }

        /// <summary>   Gets or sets the cache. </summary>
        /// <value> The cache. </value>
        protected IMemoryCache Cache { get; }

        /// <summary>   Gets the name of the model type. </summary>
        /// <value> The name of the model type. </value>
        protected string ModelTypeName => typeof(TModel).Name;

        /// <summary>   Gets cache key. </summary>
        /// <param name="obj">    The model. </param>
        /// <returns>   The cache key. </returns>
        protected virtual string GetCacheKey(object obj)
        {
            return obj == null ? $"{ModelTypeName}.NULL" : $"{ModelTypeName}.{obj.GetHashCode()}";
        }

        /// <summary>   Gets all items in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        protected override async Task<IEnumerable<TModel>> GetAll()
        {
            var key = $"{ModelTypeName}.{nameof(GetAll)}";
            if (Cache.TryGetValue(key, out IEnumerable<TModel> entry)) return entry;

            var options =
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(
                    new DateTimeOffset(DateTime.Now.Add(CacheExpiration)));
            entry = await base.GetAll();
            Cache.Set(key, entry, options);

            return entry;
        }

        /// <summary>   Gets a task&lt; t model&gt; using the given identifier. </summary>
        /// <param name="id">   The Identifier to get. </param>
        /// <returns>   An asynchronous result that yields a TModel. </returns>
        protected override async Task<TModel> Get(int id)
        {
            var key = GetCacheKey(id);
            if (Cache.TryGetValue(key, out TModel entry)) return entry;

            var options =
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(
                    new DateTimeOffset(DateTime.Now.Add(CacheExpiration)));
            entry = await base.Get(id);
            Cache.Set(key, entry, options);

            return entry;
        }
    }
}