using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Failure.EditFailureStatus
{
    public class EditFailureStatusCommand : IRequest<int>
    {
        public EditFailureStatusCommand(int failureId, int statusId)
        {
            StatusId = statusId;
            FailureId = failureId;
        }

        public int StatusId { get; }

        public int FailureId { get; }
    }
}
