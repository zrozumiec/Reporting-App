using AutoMapper;
using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Failure.EditFailureStatus
{
    public class EditFailureStatusCommandHandler : IRequestHandler<EditFailureStatusCommand, int>
    {
        private readonly IFailureRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditFailureStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure repository.</param>
        public EditFailureStatusCommandHandler(IFailureRepository repository)
        {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(EditFailureStatusCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.EditStatusAsync(request.FailureId, request.StatusId);
        }
    }
}
