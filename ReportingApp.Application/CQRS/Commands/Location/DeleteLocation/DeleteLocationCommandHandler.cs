using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Location.DeleteLocation
{
    /// <summary>
    /// Command handler to edit existing location.
    /// </summary>
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly IFailureLocationRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLocationCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure location repository.</param>
        public DeleteLocationCommandHandler(IFailureLocationRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            await this.repository.DeleteAsync(request.Id);
        }
    }
}
