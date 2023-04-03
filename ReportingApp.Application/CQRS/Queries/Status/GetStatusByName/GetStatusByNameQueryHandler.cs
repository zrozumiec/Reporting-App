using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryByName
{
    /// <summary>
    /// Query handler to get failure category by name.
    /// </summary>
    public class GetStatusByNameQueryHandler : IRequestHandler<GetStatusByNameQuery, FailureStatusDto>
    {
        private readonly IFailureStatusRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStatusByNameQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        /// <param name="mapper">Failure status mapper.</param>
        public GetStatusByNameQueryHandler(IFailureStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<FailureStatusDto> Handle(GetStatusByNameQuery request, CancellationToken cancellationToken)
        {
            var status = await this.repository.GetByNameAsync(request.Name);

            var statusDto = this.mapper.Map<FailureStatusDto>(status);

            return statusDto;
        }
    }
}
