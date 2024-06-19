    namespace EFAssignment2.Core.Interfaces
    {
        /// <summary>
        /// Represents a generic repository interface for CRUD operations.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        public interface IRepository<T>
        {
            /// <summary>
            /// Retrieves an entity by its ID asynchronously.
            /// </summary>
            /// <param name="id">The ID of the entity.</param>
            /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
            Task<T> GetByIdAsync(long id);

            /// <summary>
            /// Retrieves all entities asynchronously.
            /// </summary>
            /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
            Task<IEnumerable<T>> GetAllAsync();

            /// <summary>
            /// Adds a new entity asynchronously.
            /// </summary>
            /// <param name="entity">The entity to add.</param>
            /// <returns>A task that represents the asynchronous operation.</returns>
            Task AddAsync(T entity);

            /// <summary>
            /// Updates an existing entity asynchronously.
            /// </summary>
            /// <param name="entity">The entity to update.</param>
            /// <returns>A task that represents the asynchronous operation.</returns>
            Task UpdateAsync(T entity);

            /// <summary>
            /// Deletes an entity by its ID asynchronously.
            /// </summary>
            /// <param name="id">The ID of the entity to delete.</param>
            /// <returns>A task that represents the asynchronous operation.</returns>
            Task DeleteAsync(long id);
        }
    }
