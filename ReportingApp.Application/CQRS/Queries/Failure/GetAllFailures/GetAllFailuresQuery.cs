using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetAllFailures
{
    public class GetAllFailuresQuery : IRequest<ICollection<FailureDto>>
    {
    }
}
