using Microsoft.AspNetCore.Identity;

namespace ReportingApp.Domain.Entities
{
    /// <summary>
    /// Extended user identity class.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets user solutions.
        /// </summary>
        public virtual ICollection<FailureSolution> Solutions { get; set; } = new List<FailureSolution>();

        /// <summary>
        /// Gets or sets user failures.
        /// </summary>
        public virtual ICollection<Failure> Failures { get; set; } = new List<Failure>();
    }
}
