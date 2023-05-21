using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces.Base;

namespace ReportingApp.Domain.Interfaces
{
    /// <summary>
    /// Interface for failure solution repository.
    /// </summary>
    public interface IFailureSolutionRepository : IBaseRepository<FailureSolution>
    {
        /// <summary>
        /// Async method to set solution as accepted.
        /// </summary>
        /// <param name="id">Solution id.</param>
        /// <returns>Accepted solution id.</returns>
        /// <exception cref="ArgumentException">Throws when solution with given id does not exist in database.</exception>
        public Task<int> AcceptSolutionAsync(int id);
    }
}
