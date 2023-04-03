using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryById
{
    /// <summary>
    /// Query to get failure category by id.
    /// </summary>
    public class GetCategoryByIdQuery : IRequest<FailureCategoryDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByIdQuery"/> class.
        /// </summary>
        /// <param name="id">Category id.</param>
        public GetCategoryByIdQuery(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets category id.
        /// </summary>
        public int Id { get; }
    }
}
