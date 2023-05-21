using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Solution.AcceptSolution
{
    public class AcceptSolutionCommand : IRequest<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptSolutionCommand"/> class.
        /// </summary>
        /// <param name="solutionId">Solution id.</param>
        public AcceptSolutionCommand(int solutionId)
        {
            this.SolutionId = solutionId;
        }

        /// <summary>
        /// Gets solution id.
        /// </summary>
        public int SolutionId { get; }
    }
}
