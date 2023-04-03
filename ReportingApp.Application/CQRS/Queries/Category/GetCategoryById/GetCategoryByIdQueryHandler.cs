using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryById
{
    /// <summary>
    /// Query handler to get failure category by id.
    /// </summary>
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, FailureCategoryDto>
    {
        private readonly IFailureCategoryRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        /// <param name="mapper">Failure category mapper.</param>
        public GetCategoryByIdQueryHandler(IFailureCategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<FailureCategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetByIdAsync(request.Id);

            var categoryDto = this.mapper.Map<FailureCategoryDto>(category);

            return categoryDto;
        }
    }
}
