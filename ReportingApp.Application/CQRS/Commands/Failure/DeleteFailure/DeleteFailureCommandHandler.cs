using AutoMapper;
using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Failure.DeleteFailure
{
    public class DeleteFailureCommandHandler : IRequestHandler<DeleteFailureCommand, int>
    {
        private readonly IFailureRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteFailureCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure repository.</param>
        public DeleteFailureCommandHandler(IFailureRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(DeleteFailureCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.DeleteAsync(request.FailureId);
        }
    }
}
