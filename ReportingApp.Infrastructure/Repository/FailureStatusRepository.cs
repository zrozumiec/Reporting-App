using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure status repository.
    /// </summary>
    public class FailureStatusRepository : BaseRepository<FailureStatus>, IFailureStatusRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureStatusRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureStatusRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<FailureStatus> DbSet => this.DbContext.FailureStatuses;

        /// <inheritdoc/>
        public async Task<FailureStatus?> GetByNameAsync(string name)
        {
            var status = await this.DbSet
                .AsNoTracking()
                .Include(x => x.Failures)
                .FirstOrDefaultAsync(x => x.Name == name);

            return status;
        }

        /// <inheritdoc/>
        public async Task<FailureStatus?> GetByIdAsync(int id)
        {
            var status = await this.DbSet
                .AsNoTracking()
                .Include(x => x.Failures)
                .FirstOrDefaultAsync(x => x.Id == id);

            return status;
        }

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, FailureStatus newItem)
        {
            var status = await this.DbSet.FindAsync(id);

            if (status is null)
            {
                throw new ArgumentException("Status with given id does not exist in database.");
            }

            status.Name = newItem.Name;

            await this.SaveAsync();

            return status.Id;
        }
    }
}
