using MediatR;

namespace ReportingApp.Application.CQRS.Commands.FailureType.GetFailureTypeById
{
    public class DeleteFailureTypeByIdCommand : IRequest<int>
    {
        public DeleteFailureTypeByIdCommand(int failureTypeId)
        {
            FailureTypeId = failureTypeId;
        }

        public int FailureTypeId { get; }
    }
}
