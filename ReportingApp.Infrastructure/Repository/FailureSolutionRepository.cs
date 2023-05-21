using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure solution repository.
    /// </summary>
    public class FailureSolutionRepository : BaseRepository<FailureSolution>, IFailureSolutionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureSolutionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureSolutionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<FailureSolution> DbSet => this.DbContext.FailureSolutions;

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, FailureSolution newItem)
        {
            var solution = await this.DbSet.FindAsync(id);

            if (solution is null)
            {
                throw new ArgumentException("Solution with given id does not exist in database.");
            }

            solution.Accepted = newItem.Accepted;
            solution.Description = newItem.Description;
            solution.ExpectedCostMin = newItem.ExpectedCostMin;
            solution.ExpectedCostMax = newItem.ExpectedCostMax;
            solution.FailureId = newItem.FailureId;

            await this.SaveAsync();

            return solution.Id;
        }

        /// <inheritdoc/>
        public async Task<int> AcceptSolutionAsync(int id)
        {
            var solution = await this.DbSet.FindAsync(id);

            if (solution is null)
            {
                throw new ArgumentException("Solution with given id does not exist in database.");
            }

            solution.Accepted = true;

            await this.SaveAsync();

            return solution.Id;
        }

        /// <inheritdoc/>
        public async Task<ICollection<FailureSolution>> GetAllFailureSolutionsAsync(int failureId)
        {
            var solutions = await this.DbSet.Where(x => x.FailureId == failureId).ToListAsync();

            return solutions;
        }
    }
}