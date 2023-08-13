using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Solution.CreateSolution
{
    public class CreateSolutionCommand : FailureSolutionDto, IRequest<int>
    {
    }
}
