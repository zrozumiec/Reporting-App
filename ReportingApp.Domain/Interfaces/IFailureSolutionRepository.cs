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

        /// <summary>
        /// Async method to get all failure solutions.
        /// </summary>
        /// <param name="failureId">Failure id.</param>
        /// <returns>Collection of failure solutions.</returns>
        public Task<ICollection<FailureSolution>> GetAllFailureSolutionsAsync(int failureId);

        /// <summary>
        /// Async method to get all user failure solutions.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Collection of user failure solutions.</returns>
        public Task<ICollection<FailureSolution>> GetAllUserFailureSolutionsAsync(string userId);

        /// <summary>
        /// Async method to get all accepted user failure solutions.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Collection of accepted user failure solutions.</returns>
        public Task<ICollection<FailureSolution>> GetUserAcceptedFailureSolutionsAsync(string userId);
    }
}
