using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Solution.AcceptSolution
{
    public class AcceptSolutionCommandHandler : IRequestHandler<AcceptSolutionCommand, int>
    {
        private readonly IFailureSolutionRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptSolutionCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure solution repository.</param>
        public AcceptSolutionCommandHandler(IFailureSolutionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(AcceptSolutionCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.AcceptSolutionAsync(request.SolutionId);
        }
    }
}
