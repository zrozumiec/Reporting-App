using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Category.EditCategory
{
    /// <summary>
    /// Command handler to edit failure category.
    /// </summary>
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, int>
    {
        private readonly IFailureCategoryRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        /// <param name="mapper">Failure category mapper.</param>
        public EditCategoryCommandHandler(IFailureCategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = this.mapper.Map<FailureCategory>(request);

            return await this.repository.UpdateAsync(category.Id, category);
        }
    }
}
