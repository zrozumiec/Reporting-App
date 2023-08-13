using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Solution.CreateSolution
{
    public class CreateSolutionCommandHandler : IRequestHandler<CreateSolutionCommand, int>
    {
        private readonly IFailureSolutionRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSolutionCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure solution repository.</param>
        /// <param name="mapper">Failure solution mapper.</param>
        public CreateSolutionCommandHandler(IFailureSolutionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateSolutionCommand request, CancellationToken cancellationToken)
        {
            request.Failure = null!;
            request.User = null!;

            var solution = this.mapper.Map<FailureSolution>(request);

            await this.repository.AddAsync(solution);

            return solution.Id;
        }
    }
}
