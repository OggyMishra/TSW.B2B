// ***********************************************************************
// <copyright file="ClaimsPrincipalExtensions.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>ClaimsPrincipalExtensions class</summary>
// ***********************************************************************
namespace TSW.B2B.Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    /// <summary>
    /// ClaimsPrincipalExtensions class
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Gets List of Roles from Claims
        /// </summary>
        /// <param name="claimsPrincipal">claimsPrincipal.</param>
        /// <param name="claimType">claimType of string type.</param>
        /// <returns>It returns list of strings.</returns>
        public static IEnumerable<string> GetRolesClaimValue(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal.Claims?.ToList().Where(s => s.Type == claimType)?.Select(s => s.Value).ToList();
        }

        /// <summary>
        /// Gets Claim Value based on Calim Type
        /// </summary>
        /// <param name="claimsPrincipal">claimsPrincipal.</param>
        /// <param name="claim">claim of sting type.</param>
        /// <returns>It returns string value.</returns>
        public static string GetUserClaimValue(this ClaimsPrincipal claimsPrincipal, string claim)
        {
            return claimsPrincipal.Claims?.FirstOrDefault(o => o.Type == claim)?.Value;
        }

        /// <summary>
        /// Gets Claims User Name
        /// </summary>
        /// <param name="claimsPrincipal">claimsPrincipal.</param>
        /// <returns>It returns string value.</returns>
        public static string GetUserName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims?.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value;
        }
    }
}
