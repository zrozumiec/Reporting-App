using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Category.CreateCategory
{
    /// <summary>
    /// Command to create new failure category.
    /// </summary>
    public class CreateCategoryCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets failure category id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets failure category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
