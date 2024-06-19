using EFAssignment2.Core.Entities;
using EFAssignment2.Core.Interfaces;
using EFAssignment2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAssignment2.Infrastructure.Repositories
{
    /// <summary>
    /// Represents a repository for managing blog types.
    /// </summary>
    public class BlogTypeRepository : IBlogTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new blog type to the repository.
        /// </summary>
        /// <param name="entity">The blog type entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddAsync(BlogType entity)
        {
            try
            {
                _context.BlogTypes.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while adding the blog type: {ex.Message}");
                throw; // Rethrow the exception to the caller
            }
        }

        /// <summary>
        /// Deletes a blog type from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog type to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(long id)
        {
            try
            {
                var blogType = await _context.BlogTypes.FindAsync(id);
                if (blogType != null)
                {
                    _context.BlogTypes.Remove(blogType);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while deleting the blog type: {ex.Message}");
                throw; // Rethrow the exception to the caller
            }
        }

        /// <summary>
        /// Retrieves all blog types from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of blog types.</returns>
        public async Task<IEnumerable<BlogType>> GetAllAsync()
        {
            try
            {
                return await _context.BlogTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while retrieving all blog types: {ex.Message}");
                throw; // Rethrow the exception to the caller
            }
        }

        /// <summary>
        /// Retrieves a blog type from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog type to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the blog type.</returns>
        public async Task<BlogType> GetByIdAsync(long id)
        {
            try
            {
                return await _context.BlogTypes.FirstOrDefaultAsync(bt => bt.Id == id);
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while retrieving the blog type: {ex.Message}");
                throw; // Rethrow the exception to the caller
            }
        }

        /// <summary>
        /// Updates a blog type in the repository.
        /// </summary>
        /// <param name="entity">The updated blog type entity.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(BlogType entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while updating the blog type: {ex.Message}");
                throw; // Rethrow the exception to the caller
            }
        }
    }
}