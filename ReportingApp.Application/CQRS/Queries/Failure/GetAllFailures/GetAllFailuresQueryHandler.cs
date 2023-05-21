using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetAllFailures
{
    public class GetAllFailuresQueryHandler : IRequestHandler<GetAllFailuresQuery, ICollection<FailureDto>>
    {
        private readonly IFailureRepository repository;
        private readonly IMapper mapper;

        public GetAllFailuresQueryHandler(IFailureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<FailureDto>> Handle(GetAllFailuresQuery request, CancellationToken cancellationToken)
        {
            var failures = await this.repository.GetAllAsync();
            var failuresDto = this.mapper.Map<ICollection<FailureDto>>(failures);

            return failuresDto;
        }
    }
}
