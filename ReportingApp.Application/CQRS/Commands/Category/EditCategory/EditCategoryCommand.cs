using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Category.EditCategory
{
    /// <summary>
    /// Command to edit failure category.
    /// </summary>
    public class EditCategoryCommand : IRequest<int>
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
