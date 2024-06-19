
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFAssignment2.Core.Entities;
using EFAssignment2.Core.Interfaces;
using EFAssignment2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFAssignment2.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for managing user data.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The application database context.</param>
        /// <param name="logger">The logger.</param>
        public UserRepository(ApplicationDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new user asynchronously.
        /// </summary>
        /// <param name="entity">The user entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(User entity)
        {
            try
            {
                await _dbContext.Users.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                _logger.LogError($"An error occurred while adding the user: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a user asynchronously by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(long id)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                _logger.LogError($"An error occurred while deleting the user: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets all users asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving all users: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets a user by email asynchronously.
        /// </summary>
        /// <param name="emailAddress">The email address of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<User> GetByEmailAsync(string emailAddress)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the user by email: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets a user by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<User> GetByIdAsync(long id)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the user by ID: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Updates a user asynchronously.
        /// </summary>
        /// <param name="entity">The user entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(User entity)
        {
            try
            {
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == entity.Id);
                existingUser.EmailAddress = entity.EmailAddress;
                existingUser.Name = entity.Name;
                existingUser.PhoneNumber = entity.PhoneNumber;
                existingUser.UpdatedDateTime = DateTime.UtcNow;
                _dbContext.Users.Update(existingUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the user: {ex.Message}");
                throw;
            }
        }
    }
}
