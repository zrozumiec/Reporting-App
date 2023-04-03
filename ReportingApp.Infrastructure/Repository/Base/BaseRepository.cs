using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities.Base;
using ReportingApp.Domain.Interfaces.Base;

namespace ReportingApp.Infrastructure.Repository.Base
{
    /// <summary>
    /// Abstract base repository class.
    /// </summary>
    /// <typeparam name="T">ToDoApp item.</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">Application database context.</param>
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        /// <summary>
        /// Gets database context.
        /// </summary>
        protected ApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets DbSet of type T.
        /// </summary>
        protected abstract DbSet<T> DbSet { get; }

        /// <inheritdoc/>
        public async Task<int> AddAsync(T item)
        {
            await this.DbSet.AddAsync(item);
            await this.SaveAsync();

            return item.Id;
        }

        /// <inheritdoc/>
        public async Task<int> DeleteAsync(int id)
        {
            var task = await this.DbSet.FindAsync(id);

            if (task is null)
            {
                throw new ArgumentException("Item with given id does not exist in database.");
            }

            this.DbSet.Remove(task);
            await this.SaveAsync();

            return task.Id;
        }

        /// <inheritdoc/>
        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await this.DbSet.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await this.DbSet.FindAsync(id);
        }

        /// <inheritdoc/>
        public abstract Task<int> UpdateAsync(int id, T newItem);

        /// <summary>
        /// Save all changes made in db context.
        /// </summary>
        /// <returns>Result of save operation.</returns>
        protected async Task<int> SaveAsync()
        {
            return await this.DbContext.SaveChangesAsync();
        }
    }
}
