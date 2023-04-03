using AutoMapper;
using MediatR;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Location.EditLocation
{
    /// <summary>
    /// Command handler to edit existing location.
    /// </summary>
    public class EditLocationCommandHandler : IRequestHandler<EditLocationCommand>
    {
        private readonly IFailureLocationRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditLocationCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure location repository.</param>
        /// <param name="mapper">Failure location mapper.</param>
        public EditLocationCommandHandler(IFailureLocationRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task Handle(EditLocationCommand request, CancellationToken cancellationToken)
        {
            var updatedLocation = this.mapper.Map<FailureLocation>(request);

            await this.repository.UpdateAsync(request.Id, updatedLocation);
        }
    }
}
