using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Failure.DeleteFailure
{
    public class DeleteFailureCommand : IRequest<int>
    {
        public DeleteFailureCommand(int failureId)
        {
            FailureId = failureId;
        }

        public int FailureId { get; }
    }
}
