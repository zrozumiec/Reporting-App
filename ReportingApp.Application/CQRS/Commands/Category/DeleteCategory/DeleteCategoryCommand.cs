using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Category.DeleteCategory
{
    /// <summary>
    /// Command to delete failure category.
    /// </summary>
    public class DeleteCategoryCommand : IRequest<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCategoryCommand"/> class.
        /// </summary>
        /// <param name="id">Category id to delete.</param>
        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets category id to delete.
        /// </summary>
        public int Id { get; }
    }
}
