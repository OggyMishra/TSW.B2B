// ***********************************************************************
// <copyright file="IUserService.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>IUserService Interface</summary>
// ***********************************************************************

namespace TSW.B2B.BusinessServices.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessObjects;

    /// <summary>
    /// IUserService Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task AddNewUser(User user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> UpdateUser(User user);
}
}
