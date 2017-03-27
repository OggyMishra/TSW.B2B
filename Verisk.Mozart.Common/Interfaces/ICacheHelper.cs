// ***********************************************************************
// <copyright file="ICacheHelper.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>ICacheHelper class</summary>
// ***********************************************************************
namespace TSW.B2B.Common.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ICacheHelper Interface
    /// </summary>
    public interface ICacheHelper
    {
        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        void Clear(string key);

        /// <summary>
        /// clear all cache objects.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Clear cache items matching where.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        void ClearWhere(Func<KeyValuePair<string, object>, bool> predicate);

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns>return boolean whether or not if the value exists</returns>
        bool Exists(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T">Type of key</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns value for given key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// The invalidate.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        void Invalidate(string key);

        /// <summary>
        /// The set.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        void Set(string key, object data);

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
        void Set(string key, object data, int cacheTime);
    }
}