using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Status.DeleteStatus
{
    public sealed class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, int>
    {
        private readonly IFailureStatusRepository repository;

        public DeleteStatusCommandHandler(IFailureStatusRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.DeleteAsync(request.Id);
        }
    }
}
