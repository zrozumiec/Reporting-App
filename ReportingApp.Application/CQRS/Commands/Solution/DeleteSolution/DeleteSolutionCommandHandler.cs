using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Solution.DeleteSolution
{
    public class DeleteSolutionCommandHandler : IRequestHandler<DeleteSolutionCommand, int>
    {
        private readonly IFailureSolutionRepository repository;

        public DeleteSolutionCommandHandler(IFailureSolutionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(DeleteSolutionCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.DeleteAsync(request.SolutionId);
        }
    }
}
