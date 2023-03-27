using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces.Base;

namespace ReportingApp.Domain.Interfaces
{
    /// <summary>
    /// Interface for failure status repository.
    /// </summary>
    public interface IFailureStatusRepository : IBaseRepositroy<FailureStatus>
    {
        /// <summary>
        /// Async method returns status with given name.
        /// </summary>
        /// <param name="name">Status name.</param>
        /// <returns>Status with specified name.</returns>
        /// <exception cref="ArgumentException">Throws when status with given name does not exist in database.</exception>
        Task<FailureStatus?> GetByNameAsync(string name);
    }
}
