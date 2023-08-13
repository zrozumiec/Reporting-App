using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetAcceptedFailures
{
    public class GetAcceptedFailuresQuery : IRequest<ICollection<FailureSolutionDto>>
    {
        public GetAcceptedFailuresQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
