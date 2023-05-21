using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces.Base;

namespace ReportingApp.Domain.Interfaces
{
    /// <summary>
    /// Interface for failure repository.
    /// </summary>
    public interface IFailureRepository : IBaseRepository<Failure>
    {
        public Task<ICollection<Failure>> GetAllUserFailuresAsync(string userId);

        /// <summary>
        /// Async method to edit failure status.
        /// </summary>
        /// <param name="failureId">Failure id.</param>
        /// <param name="statusId">Status id.</param>
        /// <returns>Edited failure id.</returns>
        /// <exception cref="ArgumentException">Throws when failure does not exist.</exception>
        public Task<int> EditStatusAsync(int failureId, int statusId);
    }
}
