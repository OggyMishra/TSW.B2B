// ***********************************************************************
// <copyright file="StringExtensions.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>StringExtensions class</summary>
// ***********************************************************************
namespace TSW.B2B.Common.Extensions
{
    using System;

    /// <summary>
    /// StringExtensions class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Equalses the ignore case, uses StringComparison.OrdinalIgnoreCase.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <returns>true if both string are equals</returns>
        public static bool EqualsIgnoreCase(this string value, string valueToCompare)
        {
            if (value != null)
            {
                return value.Equals(valueToCompare, StringComparison.OrdinalIgnoreCase);
            }

            return valueToCompare == null;
        }

        /// <summary>
        /// trancates a string upto max characters
        /// </summary>
        /// <param name="valueToTruncate">stringToTruncate.</param>
        /// <param name="maxLength">maxLength.</param>
        /// <returns>It returns string value.</returns>
        public static string TruncateForLogging(this string valueToTruncate, int maxLength)
        {
            if (string.IsNullOrEmpty(valueToTruncate))
            {
                return valueToTruncate;
            }

            return valueToTruncate.Length <= maxLength ? valueToTruncate : valueToTruncate.Substring(0, maxLength);
        }

        /// <summary>
        /// trancates a string upto max characters
        /// </summary>
        /// <param name="valueToTruncate">stringToTruncate.</param>
        /// <returns>It returns string value.</returns>
        public static string TruncateForLogging(this string valueToTruncate)
        {
            return TruncateForLogging(valueToTruncate, 10000);
        }
    }
}
