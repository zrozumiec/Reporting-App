using Microsoft.AspNetCore.Identity;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Extended user identity class.
    /// </summary>
    public class ApplicationUserDto : IdentityUser
    {
        /// <summary>
        /// Gets or sets user solutions.
        /// </summary>
        public ICollection<FailureSolutionDto> Solutions { get; set; } = new List<FailureSolutionDto>();

        /// <summary>
        /// Gets or sets user failures.
        /// </summary>
        public ICollection<FailureDto> Failures { get; set; } = new List<FailureDto>();
    }
}
