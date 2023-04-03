using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Category.GetCategoryByName
{
    /// <summary>
    /// Query handler to get failure category by name.
    /// </summary>
    public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, FailureCategoryDto>
    {
        private readonly IFailureCategoryRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryByNameQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        /// <param name="mapper">Failure category mapper.</param>
        public GetCategoryByNameQueryHandler(IFailureCategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<FailureCategoryDto> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var category = await this.repository.GetByNameAsync(request.Name);

            var categoryDto = this.mapper.Map<FailureCategoryDto>(category);

            return categoryDto;
        }
    }
}
