using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetFailureById
{
    public class GetFailureByIdQuery : IRequest<FailureDto>
    {

        public GetFailureByIdQuery(int failureId)
        {
            FailureId = failureId;
        }

        public int FailureId { get; }
    }
}
