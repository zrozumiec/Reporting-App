using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Category.CreateCategory
{
    /// <summary>
    /// Command handler to create new location.
    /// </summary>
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IFailureCategoryRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        /// <param name="mapper">Failure category mapper.</param>
        public CreateCategoryCommandHandler(IFailureCategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = this.mapper.Map<FailureCategory>(request);

            return await this.repository.AddAsync(category);
        }
    }
}
