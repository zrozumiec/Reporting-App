using ReportingApp.Application.CQRS.Commands.Failure.CreateFailuire;

namespace ReportingApp.UI.Models.FailureVM
{
    public class CreateNewFailureVM
    {
        public List<AddFailureTypeToFailure> AddMoreFailureTypes { get; set; } = new List<AddFailureTypeToFailure>();

        public CreateFailureCommand CreateFailureCommand { get; set; } = new CreateFailureCommand();
    }
}
