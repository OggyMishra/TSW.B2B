// ***********************************************************************
// <copyright file="CacheHelper.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>CacheHelper class</summary>
// ***********************************************************************
namespace TSW.B2B.Common.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;

    using TSW.B2B.Common.Interfaces;

    /// <summary>
    /// CacheHelper class implements ICacheHelper
    /// </summary>
    public class CacheHelper : ICacheHelper
    {
        /// <summary>
        /// lock object
        /// </summary>
        private static readonly object LockObject = new object();

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <value>
        /// The cache.
        /// </value>
        private ObjectCache Cache => MemoryCache.Default;

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public void Clear(string key)
        {
            this.Cache.Remove(key);
        }

        /// <summary>
        /// clear all cache objects.
        /// </summary>
        public void ClearAll()
        {
            List<string> cacheKeys = this.Cache.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                this.Cache.Remove(cacheKey);
            }
        }

        /// <summary>
        /// Clear cache items matching where.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        public void ClearWhere(Func<KeyValuePair<string, object>, bool> predicate)
        {
            List<string> cacheKeys = this.Cache.Where(predicate).Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                this.Cache.Remove(cacheKey);
            }
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>return boolean whether or not if the value exists</returns>
        public bool Exists(string key)
        {
            return this.Cache[key] != null;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public T Get<T>(string key)
        {
            T value;

            try
            {
                if (!this.Exists(key))
                {
                    value = default(T);
                    return value;
                }

                value = (T)this.Cache[key];
            }
            catch
            {
                value = default(T);
                return value;
            }

            return value;
        }

        /// <summary>
        /// The invalidate.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void Invalidate(string key)
        {
            this.Cache.Remove(key);
        }

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public void Set(string key, object data)
        {
            lock (LockObject)
            {
                this.Set(key, data, 30);
            }
        }

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="cacheTime">
        /// The cache time.
        /// </param>
        public void Set(string key, object data, int cacheTime)
        {
            lock (LockObject)
            {
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
                };

                this.Cache.Add(new CacheItem(key, data), policy);
            }
        }
    }
}