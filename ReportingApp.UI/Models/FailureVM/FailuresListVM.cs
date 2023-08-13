using ReportingApp.Application.DTO;

namespace ReportingApp.UI.Models.FailureVM
{
    public class FailuresListVM
    {
        public ICollection<FailureDto> Failures { get; set; } = new List<FailureDto>();

        public bool AccesToEdit { get; set; }
    }
}
