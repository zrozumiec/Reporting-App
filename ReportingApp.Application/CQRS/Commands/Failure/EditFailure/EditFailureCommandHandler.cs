using AutoMapper;
using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Failure.EditFailure
{
    public class EditFailureCommandHandler : IRequestHandler<EditFailureCommand, int>
    {
        private readonly IFailureRepository repository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditFailureCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">Failure repository.</param>
        public EditFailureCommandHandler(IFailureRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(EditFailureCommand request, CancellationToken cancellationToken)
        {
            var editedFailure = this.mapper.Map<ReportingApp.Domain.Entities.Failure>(request.Failure);

            return await this.repository.UpdateAsync(request.Failure.Id, editedFailure);
        }
    }
}
