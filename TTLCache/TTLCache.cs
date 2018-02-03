using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTLCache
{
    public class TTLCache : ITTLCache
    {
        private Dictionary<string, CacheItem> _cache;
        public int CacheDurationInDays { get; set; }

        /// <summary>
        /// Initialize TTL Cache with Duration in Days
        /// </summary>
        /// <param name="cacheDuration"></param>
        public TTLCache(int cacheDuration)
        {
            this.CacheDurationInDays = cacheDuration;
            _cache = new Dictionary<string, CacheItem>();
        }
        /// <summary>
        /// Private method to get cached object
        /// </summary>
        /// <param name="key"></param>
        /// <returns>CachedItem or null</returns>
        private CacheItem GetCacheItem(string key)
        {
            if (!this._cache.ContainsKey(key))
            {
                return null;
            }
            return this._cache[key];
        }
        /// <summary>
        /// Adds new cache item into Cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            CacheItem cacheItem = this.GetCacheItem(key);
            if (cacheItem != null)
            {
                cacheItem.UpdateExpiry();
            }
            else
            {
                _cache.Add(key, new CacheItem(value));
            }
        }
        /// <summary>
        /// Gets cached value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Cached value. Null if item is expired or not found</returns>
        public string Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Argument Null or Empty", "Key");
            }
            CacheItem cacheItem = this.GetCacheItem(key);
            if (cacheItem == null)
            {
                return null;
            }
            if (!cacheItem.IsValid(this.CacheDurationInDays))
            {
                this._cache.Remove(key);
                return null;
            }
            return cacheItem.Value;
        }
        /// <summary>
        /// Current number cached items.
        /// </summary>
        /// <returns>Count of non-expired cache items</returns>
        public int Count()
        {
            int count = 0;
            foreach (var key in this._cache.Keys)
            {
                if(this._cache[key].IsValid(this.CacheDurationInDays))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Empty current Cache
        /// </summary>
        public void Clear()
        {
            this._cache.Clear();
        }
    }
}
