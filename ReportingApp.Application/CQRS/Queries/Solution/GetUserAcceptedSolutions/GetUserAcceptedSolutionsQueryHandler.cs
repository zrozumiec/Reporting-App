using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetAUserAcceptedSolutions
{
    public class GetUserAcceptedSolutionsQueryHandler : IRequestHandler<GetUserAcceptedSolutionsQuery, ICollection<FailureSolutionDto>>
    {
        private readonly IFailureSolutionRepository repository;
        private readonly IMapper mapper;

        public GetUserAcceptedSolutionsQueryHandler(IFailureSolutionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<FailureSolutionDto>> Handle(GetUserAcceptedSolutionsQuery request, CancellationToken cancellationToken)
        {
            var acceptedSolutions = await this.repository.GetUserAcceptedFailureSolutionsAsync(request.UserId);

            return this.mapper.Map<ICollection<FailureSolutionDto>>(acceptedSolutions);
        }
    }
}
