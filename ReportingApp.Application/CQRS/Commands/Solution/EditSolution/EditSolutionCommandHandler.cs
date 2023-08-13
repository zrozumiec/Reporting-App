using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Solution.EditSolution
{
    public class EditSolutionCommandHandler : IRequestHandler<EditSolutionCommand, int>
    {
        private readonly IFailureSolutionRepository repository;
        private readonly IMapper mapper;

        public EditSolutionCommandHandler(IFailureSolutionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(EditSolutionCommand request, CancellationToken cancellationToken)
        {
            var editedSolution = this.mapper.Map<FailureSolution>(request);

            return await this.repository.UpdateAsync(request.Id, editedSolution);
        }
    }
}
