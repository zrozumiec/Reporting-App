using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Solution.EditSolution
{
    public class EditSolutionCommand : FailureSolutionDto, IRequest<int>
    {
    }
}
