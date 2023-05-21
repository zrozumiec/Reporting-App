using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetAllUserFailures
{
    public class GetAllUserFailuresQueryHandler : IRequestHandler<GetAllUserFailuresQuery, ICollection<FailureDto>>
    {
        private readonly IFailureRepository repository;
        private readonly IMapper mapper;

        public GetAllUserFailuresQueryHandler(IFailureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ICollection<FailureDto>> Handle(GetAllUserFailuresQuery request, CancellationToken cancellationToken)
        {
            var userFailures = await this.repository.GetAllUserFailuresAsync(request.UserId);
            var userFailuresDto = this.mapper.Map<ICollection<FailureDto>>(userFailures);

            return userFailuresDto;
        }
    }
}
