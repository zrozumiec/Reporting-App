using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Solution.GetUserSolutions
{
    public class GetUserSolutionsQueryHandler : IRequestHandler<GetUserSolutionsQuery, ICollection<FailureSolutionDto>>
    {
        private readonly IFailureSolutionRepository repository;
        private readonly IMapper mapper;

        public GetUserSolutionsQueryHandler(IFailureSolutionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<FailureSolutionDto>> Handle(GetUserSolutionsQuery request, CancellationToken cancellationToken)
        {
             var userSolutions = await this.repository.GetAllUserFailureSolutionsAsync(request.UserId);

             return this.mapper.Map<ICollection<FailureSolutionDto>>(userSolutions);
        }
    }
}
