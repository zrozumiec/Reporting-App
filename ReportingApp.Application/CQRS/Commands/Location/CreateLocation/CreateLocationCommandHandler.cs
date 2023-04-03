using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Location.CreateLocation
{
    /// <summary>
    /// Command handler to create new location.
    /// </summary>
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IFailureLocationRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLocationCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure location repository.</param>
        /// <param name="mapper">Failure location mapper.</param>
        public CreateLocationCommandHandler(IFailureLocationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = this.mapper.Map<FailureLocation>(request);

            await this.repository.AddAsync(location);
        }
    }
}
