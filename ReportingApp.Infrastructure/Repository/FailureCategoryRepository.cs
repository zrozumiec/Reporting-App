using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure category repository.
    /// </summary>
    public class FailureCategoryRepository : BaseRepository<FailureCategory>, IFailureCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureCategoryRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureCategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<FailureCategory> DbSet => this.DbContext.FailureCategories;

        /// <inheritdoc/>
        public async Task<FailureCategory?> GetByNameAsync(string name)
        {
            return await this.DbSet
                .AsNoTracking()
                .Include(x => x.FailureTypes)
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        /// <inheritdoc/>
        public override async Task<FailureCategory?> GetByIdAsync(int id)
        {
            return await this.DbSet
                .AsNoTracking()
                .Include(x => x.FailureTypes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, FailureCategory newItem)
        {
            var category = await this.DbSet.FindAsync(id);

            if (category is null)
            {
                throw new ArgumentException("Category with given id does not exist in database.");
            }

            category.Name = newItem.Name;
            await this.SaveAsync();

            return category.Id;
        }
    }
}