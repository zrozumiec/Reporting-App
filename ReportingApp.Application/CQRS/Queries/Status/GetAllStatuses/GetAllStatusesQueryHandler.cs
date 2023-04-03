using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Status.GetAllStatuses
{
    /// <summary>
    /// Query handler to get all failure statuses.
    /// </summary>
    public class GetAllStatusesQueryHandler : IRequestHandler<GetAllStatusesQuery, ICollection<FailureStatusDto>>
    {
        private readonly IFailureStatusRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStatusesQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        /// <param name="mapper">Failure status mapper.</param>
        public GetAllStatusesQueryHandler(IFailureStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ICollection<FailureStatusDto>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            var statuses = await repository.GetAllAsync();

            var statusesDto = mapper.Map<ICollection<FailureStatusDto>>(statuses);

            return statusesDto;
        }
    }
}
