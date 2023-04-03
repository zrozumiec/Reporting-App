using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Category.DeleteCategory
{
    /// <summary>
    /// Command handler to delete failure category.
    /// </summary>
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly IFailureCategoryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCategoryCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        public DeleteCategoryCommandHandler(IFailureCategoryRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.DeleteAsync(request.Id);
        }
    }
}
