using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Location.CreateLocation
{
    /// <summary>
    /// Command to create new location.
    /// </summary>
    public class CreateLocationCommand : FailureLocationDto, IRequest
    {
    }
}
