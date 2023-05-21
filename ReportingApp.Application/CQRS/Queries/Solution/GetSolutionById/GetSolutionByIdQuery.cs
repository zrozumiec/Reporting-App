using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetSolutionById
{
    public class GetSolutionByIdQuery : IRequest<FailureSolutionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSolutionByIdQuery"/> class.
        /// </summary>
        /// <param name="solutionId">Solution id.</param>
        public GetSolutionByIdQuery(int solutionId)
        {
            this.SolutionId = solutionId;
        }

        /// <summary>
        /// Gets solution id.
        /// </summary>
        public int SolutionId { get; }
    }
}
