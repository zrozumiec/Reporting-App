using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Status.CreateStatus
{
    /// <summary>
    /// Command handler to create new status.
    /// </summary>
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, int>
    {
        private readonly IFailureStatusRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStatusCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        /// <param name="mapper">Failure status mapper.</param>
        public CreateStatusCommandHandler(IFailureStatusRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = this.mapper.Map<FailureStatus>(request);

            return await this.repository.AddAsync(status);
        }
    }
}
