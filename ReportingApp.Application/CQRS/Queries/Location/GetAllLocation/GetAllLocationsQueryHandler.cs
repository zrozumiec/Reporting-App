using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Location.GetAllLocation
{
    /// <summary>
    /// Query handler to get all locations.
    /// </summary>
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, ICollection<FailureLocationDto>>
    {
        private readonly IFailureLocationRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLocationsQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure location repository.</param>
        /// <param name="mapper">Failure location mapper.</param>
        public GetAllLocationsQueryHandler(IFailureLocationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ICollection<FailureLocationDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await this.repository.GetAllAsync();

            var locationsDto = this.mapper.Map<ICollection<FailureLocationDto>>(locations);

            return locationsDto;
        }
    }
}
