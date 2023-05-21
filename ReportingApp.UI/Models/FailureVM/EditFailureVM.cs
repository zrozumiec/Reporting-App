using ReportingApp.Application.CQRS.Commands.Failure.EditFailure;

namespace ReportingApp.UI.Models.FailureVM
{
    public class EditFailureVM
    {
        public EditFailureCommand EditFailureCommand { get; set; } = new EditFailureCommand();

        public FailureCategoriesSelectedList FailureCategoriesSelectedList { get; set; } = new();

        public List<AddFailureTypeToFailure> AddMoreFailureTypes { get; set; } = new List<AddFailureTypeToFailure>();
    }
}
