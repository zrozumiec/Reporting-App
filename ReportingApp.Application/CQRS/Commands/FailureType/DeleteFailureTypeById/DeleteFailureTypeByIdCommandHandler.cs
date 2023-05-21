using MediatR;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.FailureType.GetFailureTypeById
{
    public class DeleteFailureTypeByIdCommandHandler : IRequestHandler<DeleteFailureTypeByIdCommand, int>
    {
        private readonly IFailureTypeRepository repository;

        public DeleteFailureTypeByIdCommandHandler(IFailureTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(DeleteFailureTypeByIdCommand request, CancellationToken cancellationToken)
        {
            return await this.repository.DeleteAsync(request.FailureTypeId);
        }
    }
}
