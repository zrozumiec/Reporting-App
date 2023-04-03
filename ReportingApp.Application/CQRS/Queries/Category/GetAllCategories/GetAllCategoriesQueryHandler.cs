using AutoMapper;
using MediatR;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Queries.Category.GetAllCategories
{
    /// <summary>
    /// Query handler to get all failure categories.
    /// </summary>
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ICollection<FailureCategoryDto>>
    {
        private readonly IFailureCategoryRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCategoriesQueryHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        /// <param name="mapper">Failure category mapper.</param>
        public GetAllCategoriesQueryHandler(IFailureCategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ICollection<FailureCategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await this.repository.GetAllAsync();

            var categoriesDto = this.mapper.Map<ICollection<FailureCategoryDto>>(categories);

            return categoriesDto;
        }
    }
}
