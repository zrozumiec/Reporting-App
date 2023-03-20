using ReportingApp.Domain.Entities.Base;

namespace ReportingApp.Domain.Entities
{
    /// <summary>
    /// Class represents failure.
    /// </summary>
    public class Failure : BaseEntity
    {
        /// <summary>
        /// Gets or sets failure name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure location id.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets failure location.
        /// </summary>
        public virtual FailureLocation Location { get; set; } = new FailureLocation();

        /// <summary>
        /// Gets or sets failure status id.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets failure status.
        /// </summary>
        public virtual FailureStatus Status { get; set; } = new FailureStatus();

        /// <summary>
        /// Gets or sets failure user id.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure user.
        /// </summary>
        public virtual ApplicationUser User { get; set; } = new ApplicationUser();

        /// <summary>
        /// Gets or sets failure types.
        /// </summary>
        public virtual ICollection<FailureType> FailureTypes { get; set; } = new List<FailureType>();

        /// <summary>
        /// Gets or sets failure solutions.
        /// </summary>
        public virtual ICollection<FailureSolution> FailureSolutions { get; set; } = new List<FailureSolution>();
    }
}
