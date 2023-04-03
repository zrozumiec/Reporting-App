using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Location.EditLocation
{
    /// <summary>
    /// Command to edit new location.
    /// </summary>
    public class EditLocationCommand : FailureLocationDto, IRequest
    {
    }
}
