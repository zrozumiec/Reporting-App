using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces.Base;

namespace ReportingApp.Domain.Interfaces
{
    /// <summary>
    /// Interface for failure category repository.
    /// </summary>
    public interface IFailureCategoryRepository : IBaseRepository<FailureCategory>
    {
        /// <summary>
        /// Async method returns category with given name.
        /// </summary>
        /// <param name="name">Category name.</param>
        /// <returns>Category with specified name.</returns>
        /// <exception cref="ArgumentException">Throws when category with given name does not exist in database.</exception>
        Task<FailureCategory?> GetByNameAsync(string name);
    }
}
