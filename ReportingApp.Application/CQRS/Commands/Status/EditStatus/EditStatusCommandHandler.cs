using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Status.EditStatus
{
    /// <summary>
    /// Command handler to edit existing status.
    /// </summary>
    public class EditStatusCommandHandler : IRequestHandler<EditStatusCommand, int>
    {
        private readonly IFailureStatusRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        /// <param name="mapper">Failure status mapper.</param>
        public EditStatusCommandHandler(IFailureStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(EditStatusCommand request, CancellationToken cancellationToken)
        {
            var status = this.mapper.Map<FailureStatus>(request);

            return await this.repository.UpdateAsync(status.Id, status);
        }
    }
}
