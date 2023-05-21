using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Commands.Failure.EditFailure
{
    public class EditFailureCommand : IRequest<int>
    {
        public FailureDto Failure { get; set; }
    }
}
