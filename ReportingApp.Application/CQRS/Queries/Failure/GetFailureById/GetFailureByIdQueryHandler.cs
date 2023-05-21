using AutoMapper;
using MediatR;
using ReportingApp.Application.CQRS.Queries.Failure.GetAllFailures;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetFailureById
{
    public class GetFailureByIdQueryHandler : IRequestHandler<GetFailureByIdQuery, FailureDto>
    {
        private readonly IFailureRepository repository;
        private readonly IMapper mapper;

        public GetFailureByIdQueryHandler(IFailureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<FailureDto> Handle(GetFailureByIdQuery request, CancellationToken cancellationToken)
        {
            var failure = await this.repository.GetByIdAsync(request.FailureId);
            var failureDto = this.mapper.Map<FailureDto>(failure);

            return failureDto;
        }
    }
}
