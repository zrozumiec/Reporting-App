using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryByName
{
    /// <summary>
    /// Query to get failure category by name.
    /// </summary>
    public class GetCategoryByNameQuery : IRequest<FailureCategoryDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByNameQuery"/> class.
        /// </summary>
        /// <param name="name">Category name.</param>
        public GetCategoryByNameQuery(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets category name.
        /// </summary>
        public string Name { get; }
    }
}
