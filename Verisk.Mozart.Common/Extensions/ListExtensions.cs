// ***********************************************************************
// <copyright file="ListExtensions.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>IListExtensions class</summary>
// ***********************************************************************
namespace TSW.B2B.Common.Extensions
{
    using System.Collections.Generic;

    /// <summary>
    /// This class contains some extension methods for IList
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="T">Generic parameter for IList</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="items">The items.</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            var tempList = list as List<T>;
            if (tempList != null)
            {
                tempList.AddRange(items);
            }
            else
            {
                foreach (var item in items)
                {
                    list.Add(item);
                }
            }
        }
    }
}
