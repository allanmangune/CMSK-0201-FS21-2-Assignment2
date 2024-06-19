using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFAssignment2.Core.Entities;
using EFAssignment2.Core.Interfaces;
using EFAssignment2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EFAssignment2.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for managing blog data.
    /// </summary>
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new blog entity to the database.
        /// </summary>
        /// <param name="entity">The blog entity to add.</param>
        public async Task AddAsync(Blog entity)
        {
            try
            {
                await _context.Blogs.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while adding the blog: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a blog entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog entity to delete.</param>
        public async Task DeleteAsync(long id)
        {
            try
            {
                var blog = await _context.Blogs.FindAsync(id);
                if (blog != null)
                {
                    _context.Blogs.Remove(blog);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while deleting the blog: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves all blog entities from the database.
        /// </summary>
        /// <returns>A collection of blog entities.</returns>
        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            try
            {
                return await _context.Blogs.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while retrieving the blogs: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves a blog entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog entity to retrieve.</param>
        /// <returns>The blog entity.</returns>
        public async Task<Blog> GetByIdAsync(long id)
        {
            try
            {
                return await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while retrieving the blog: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Updates a blog entity in the database.
        /// </summary>
        /// <param name="entity">The updated blog entity.</param>
        public async Task UpdateAsync(Blog entity)
        {
            try
            {
                _context.Blogs.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"An error occurred while updating the blog: {ex.Message}");
                throw;
            }
        }
    }
}