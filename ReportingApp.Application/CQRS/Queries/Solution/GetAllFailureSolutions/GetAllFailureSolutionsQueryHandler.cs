using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetAllFailureSolutions
{
    public class GetAllFailureSolutionsQueryHandler : IRequestHandler<GetAllFailureSolutionsQuery, ICollection<FailureSolutionDto>>
    {
        private readonly IFailureSolutionRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFailureSolutionsQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure solution repository.</param>
        /// <param name="mapper">Failure solution mapper.</param>
        public GetAllFailureSolutionsQueryHandler(IFailureSolutionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<FailureSolutionDto>> Handle(GetAllFailureSolutionsQuery request, CancellationToken cancellationToken)
        {
            var failureSolutions = await this.repository.GetAllFailureSolutionsAsync(request.FailureId);

            return this.mapper.Map<ICollection<FailureSolutionDto>>(failureSolutions);
        }
    }
}
