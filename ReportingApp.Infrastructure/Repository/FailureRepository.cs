using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure repository.
    /// </summary>
    public class FailureRepository : BaseRepository<Failure>, IFailureRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Failure> DbSet => this.DbContext.Failures;

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, Failure newItem)
        {
            var failure = await this.DbSet.FindAsync(id);

            if (failure is null)
            {
                throw new ArgumentException("Failure with given id does not exist in database.");
            }

            failure.Name = newItem.Name;
            failure.Location = newItem.Location;
            failure.FailureTypes = newItem.FailureTypes;

            await this.SaveAsync();

            return failure.Id;
        }

        /// <inheritdoc/>
        public async Task<int> EditStatusAsync(int failureId, int statusId)
        {
            var failure = await this.DbSet.FindAsync(failureId);

            if (failure is null)
            {
                throw new ArgumentException("Failure with given id does not exist in database.");
            }

            failure.StatusId = statusId;

            await this.SaveAsync();

            return failure.Id;
        }

        /// <inheritdoc/>
        public override async Task<ICollection<Failure>> GetAllAsync()
        {
            return await this.DbSet
                .Include(x => x.Status)
                .Include(x => x.FailureSolutions)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<ICollection<Failure>> GetAllUserFailuresAsync(string userId)
        {
            return await this.DbSet
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public override async Task<Failure?> GetByIdAsync(int id)
        {
            return await this.DbSet
                .AsNoTracking()
                .Include(x => x.Status)
                .Include(x => x.Location)
                .Include(x => x.FailureSolutions)
                .Include(x => x.FailureTypes).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
