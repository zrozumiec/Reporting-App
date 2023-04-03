using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Entities.Base;

namespace ReportingApp.Domain.Interfaces.Base
{
    /// <summary>
    /// Interface for base repository.
    /// </summary>
    /// <typeparam name="T">Failure app entity.</typeparam>
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        /// <summary>
        /// Async method to add item of type T to database.
        /// </summary>
        /// <param name="item">Item of type T to add.</param>
        /// <returns>Added item id.</returns>
        Task<int> AddAsync(T item);

        /// <summary>
        /// Async method to delete existing item from database.
        /// </summary>
        /// <param name="id">Item id to be deleted.</param>
        /// <returns>Deleted item id.</returns>
        /// <exception cref="ArgumentException">Throws when item does not exist in database.</exception>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// Async method to update existing item in database.
        /// </summary>
        /// <param name="id">Id of item to update.</param>
        /// <param name="newItem">New item data.</param>
        /// <returns>Updated item id.</returns>
        Task<int> UpdateAsync(int id, T newItem);

        /// <summary>
        /// Async method returns item with given id.
        /// </summary>
        /// <param name="id">Item id.</param>
        /// <returns>Item with specified id.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Async method returns all items existing in database.
        /// </summary>
        /// <returns>All items of type T.</returns>
        Task<ICollection<T>> GetAllAsync();
    }
}
