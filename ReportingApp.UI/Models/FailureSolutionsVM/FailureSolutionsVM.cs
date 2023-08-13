using ReportingApp.Application.DTO;

namespace ReportingApp.UI.Models.FailureSolutions
{
    public class FailureSolutionsVM
    {
        public string CurrentUserId { get; set; }

        public bool AccesToAddSolution { get; set; }

        public bool AccesToAcceptSolution { get; set; }

        public bool AnyAccepted { get; set; }

        public FailureDto Failure { get; set; } = new FailureDto();
    }
}
