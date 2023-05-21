using ReportingApp.Application.DTO;

namespace ReportingApp.UI.Models.FailureSolutions
{
    public class FailureSolutionsVM
    {
        public bool AnyAccepted { get; set; }

        public ICollection<FailureSolutionDto> Solutions { get; set; }
    }
}
