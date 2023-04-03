using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Status.GetAllStatuses
{
    /// <summary>
    /// Query to get all failure statuses.
    /// </summary>
    public class GetAllStatusesQuery : IRequest<ICollection<FailureStatusDto>>
    {
    }
}
