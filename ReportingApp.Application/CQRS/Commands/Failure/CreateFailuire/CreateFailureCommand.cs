using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Failure.CreateFailuire
{
    public class CreateFailureCommand : FailureDto, IRequest<int>
    {
    }
}
