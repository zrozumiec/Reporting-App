using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetAUserAcceptedSolutions
{
    public class GetUserAcceptedSolutionsQuery : IRequest<ICollection<FailureSolutionDto>>
    {
        public GetUserAcceptedSolutionsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
