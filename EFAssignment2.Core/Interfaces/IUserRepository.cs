using EFAssignment2.Core.Entities;

namespace EFAssignment2.Core.Interfaces
{
    /// <summary>
    /// Represents a repository interface for CRUD operations on users.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Retrieves a user by their email asynchronously.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user.</returns>
        Task<User> GetByEmailAsync(string email);
    }
}