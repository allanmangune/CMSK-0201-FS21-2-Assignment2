using EFAssignment2.Core.Entities;

namespace EFAssignment2.Core.Interfaces
{
    /// <summary>
    /// Represents a repository interface for CRUD operations on posts.
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
    }
}