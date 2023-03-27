using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure type repository.
    /// </summary>
    public class FailureTypeRepository : BaseRepository<FailureType>, IFailureTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureTypeRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureTypeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, FailureType newItem)
        {
            var type = await this.DbSet.FindAsync(id);

            if (type is null)
            {
                throw new ArgumentException("Type with given id does not exist in database.");
            }

            type.Description = newItem.Description;
            type.CategoryId = newItem.CategoryId;

            await this.SaveAsync();

            return type.Id;
        }
    }
}
