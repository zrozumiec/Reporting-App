using AutoMapper;
using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Failure.CreateFailuire
{
    /// <summary>
    /// Command handler to create new failure.
    /// </summary>
    public class CreateFailureCommandHandler : IRequestHandler<CreateFailureCommand, int>
    {
        private readonly IFailureRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFailureCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure repository.</param>
        /// <param name="mapper">Failure mapper.</param>
        public CreateFailureCommandHandler(IFailureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<int> Handle(CreateFailureCommand request, CancellationToken cancellationToken)
        {
            var failure = this.mapper.Map<Domain.Entities.Failure>(request);

            return await this.repository.AddAsync(failure);
        }
    }
}
