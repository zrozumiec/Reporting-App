using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetAllFailureSolutions
{
    public class GetAllFailureSolutionsQuery : IRequest<ICollection<FailureSolutionDto>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFailureSolutionsQuery"/> class.
        /// </summary>
        /// <param name="failureId">Failure id.</param>
        public GetAllFailureSolutionsQuery(int failureId)
        {
            this.FailureId = failureId;
        }

        /// <summary>
        /// Gets failure id.
        /// </summary>
        public int FailureId { get; }
    }
}
