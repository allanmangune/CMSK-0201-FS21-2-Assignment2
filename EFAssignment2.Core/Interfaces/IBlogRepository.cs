using EFAssignment2.Core.Entities;

namespace EFAssignment2.Core.Interfaces
{
    /// <summary>
    /// Represents a repository interface for CRUD operations on blogs.
    /// </summary>
    public interface IBlogRepository : IRepository<Blog>
    {
    }
}