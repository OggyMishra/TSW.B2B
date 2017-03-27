

namespace TSW.B2B.Repositories.Interfaces
{
    #region Usings

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    #endregion

    /// <summary>
    /// The user repository interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// A <see cref="Task"> object that represents an asynchronous operation.
        /// </returns>
        Task AddNewUser(User user);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// <c>true</c> if the user is updated; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> UpdateUser(User user);
    }
}
