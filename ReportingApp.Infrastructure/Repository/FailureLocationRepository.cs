using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure location repository.
    /// </summary>
    public class FailureLocationRepository : BaseRepository<FailureLocation>, IFailureLocationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureLocationRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureLocationRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<FailureLocation> DbSet => this.DbContext.FailureLocations;

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, FailureLocation newItem)
        {
            var location = await this.DbSet.FindAsync(id);

            if (location is null)
            {
                throw new ArgumentException("Location with given id does not exist in database.");
            }

            location.City = newItem.City;
            location.Country = newItem.Country;
            location.Description = newItem.Description;
            location.Factory = newItem.Factory;
            location.Machine = newItem.Machine;
            location.Street = newItem.Street;

            await this.SaveAsync();

            return location.Id;
        }
    }
}
