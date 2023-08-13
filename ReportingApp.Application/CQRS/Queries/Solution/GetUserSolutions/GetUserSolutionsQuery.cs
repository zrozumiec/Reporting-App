using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetUserSolutions
{
    public class GetUserSolutionsQuery : IRequest<ICollection<FailureSolutionDto>>
    {
        public GetUserSolutionsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
