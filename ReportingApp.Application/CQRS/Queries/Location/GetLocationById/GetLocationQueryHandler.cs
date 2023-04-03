using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Location.GetLocationById
{
    /// <summary>
    /// Query handler to get specified location.
    /// </summary>
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, FailureLocationDto>
    {
        private readonly IFailureLocationRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLocationQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure location repository.</param>
        /// <param name="mapper">Failure location mapper.</param>
        public GetLocationQueryHandler(IFailureLocationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<FailureLocationDto> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var location = await this.repository.GetByIdAsync(request.LocationId);

            var locationDto = this.mapper.Map<FailureLocationDto>(location);

            return locationDto;
        }
    }
}
