using ReportingApp.Application.CQRS.Commands.Failure.CreateFailuire;

namespace ReportingApp.UI.Models.FailureVM
{
    public class AddFailureVM
    {
        public CreateFailureCommand CreateFailureCommand { get; set; } = new CreateFailureCommand();

        public FailureCategoriesSelectedList FailureCategoriesSelectedList { get; set; } = new();
    }
}
