using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Solution.DeleteSolution
{
    public class DeleteSolutionCommand : IRequest<int>
    {
        public DeleteSolutionCommand(int solutionId)
        {
            SolutionId = solutionId;
        }

        public int SolutionId { get; }
    }
}
