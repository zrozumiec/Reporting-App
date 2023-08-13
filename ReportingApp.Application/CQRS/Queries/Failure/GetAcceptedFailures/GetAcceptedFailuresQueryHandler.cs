using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetAcceptedFailures
{
    public class GetAcceptedFailuresQueryHandler : IRequestHandler<GetAcceptedFailuresQuery, ICollection<FailureSolutionDto>>
    {
        private readonly IFailureRepository repository;
        private readonly IMapper mapper;

        public GetAcceptedFailuresQueryHandler(IFailureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<FailureSolutionDto>> Handle(GetAcceptedFailuresQuery request, CancellationToken cancellationToken)
        {
            var acceptedSolutions = await this.repository.GetUserAcceptedFailuresAsync(request.UserId);

            return this.mapper.Map<ICollection<FailureSolutionDto>>(acceptedSolutions);
        }
    }
}
