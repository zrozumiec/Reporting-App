using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryById
{
    /// <summary>
    /// Query handler to get failure status by id.
    /// </summary>
    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, FailureStatusDto>
    {
        private readonly IFailureStatusRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStatusByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        /// <param name="mapper">Failure status mapper.</param>
        public GetStatusByIdQueryHandler(IFailureStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<FailureStatusDto> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await this.repository.GetByIdAsync(request.Id);

            var statusDto = this.mapper.Map<FailureStatusDto>(status);

            return statusDto;
        }
    }
}
