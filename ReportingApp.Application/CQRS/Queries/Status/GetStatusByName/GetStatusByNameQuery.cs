using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryByName
{
    /// <summary>
    /// Query to get failure status by name.
    /// </summary>
    public class GetStatusByNameQuery : IRequest<FailureStatusDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetStatusByNameQuery"/> class.
        /// </summary>
        /// <param name="name">Status name.</param>
        public GetStatusByNameQuery(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets status name.
        /// </summary>
        public string Name { get; }
    }
}
