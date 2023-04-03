using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Location.GetAllLocation
{
    /// <summary>
    /// Query to get all locations.
    /// </summary>
    public class GetAllLocationsQuery : IRequest<ICollection<FailureLocationDto>>
    {
    }
}
