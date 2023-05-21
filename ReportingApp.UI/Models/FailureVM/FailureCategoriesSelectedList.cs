using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReportingApp.UI.Models.FailureVM
{
    public class FailureCategoriesSelectedList : AddFailureTypeToFailure
    {
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
