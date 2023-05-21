using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetSolutionById
{
    public class GetSolutionByIdQueryHandler : IRequestHandler<GetSolutionByIdQuery, FailureSolutionDto>
    {
        private readonly IFailureSolutionRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSolutionByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure solution repository.</param>
        /// <param name="mapper">Failure solution mapper.</param>
        public GetSolutionByIdQueryHandler(IFailureSolutionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<FailureSolutionDto> Handle(GetSolutionByIdQuery request, CancellationToken cancellationToken)
        {
            var solution = await this.repository.GetByIdAsync(request.SolutionId);

            return this.mapper.Map<FailureSolutionDto>(solution);
        }
    }
}
