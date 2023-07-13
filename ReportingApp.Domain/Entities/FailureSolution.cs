using ReportingApp.Domain.Entities.Base;

namespace ReportingApp.Domain.Entities
{
    /// <summary>
    /// Class represents failure solution.
    /// </summary>
    public class FailureSolution : BaseEntity
    {
        /// <summary>
        /// Gets or sets solution description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets solution expected min cost.
        /// </summary>
        public decimal ExpectedCostMin { get; set; }

        /// <summary>
        /// Gets or sets solution expected max cost.
        /// </summary>
        public decimal ExpectedCostMax { get; set; }

        /// <summary>
        /// Gets or sets solution expected start time.
        /// </summary>
        public DateTimeOffset ExpectedStartTime { get; set; }

        /// <summary>
        /// Gets or sets solution expected end time.
        /// </summary>
        public DateTimeOffset ExpectedEndTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether solution is accepted.
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Gets or sets solution user id.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets solution user.
        /// </summary>
        public virtual ApplicationUser User { get; set; } = new ApplicationUser();

        /// <summary>
        /// Gets or sets solution failure id.
        /// </summary>
        public int FailureId { get; set; }

        /// <summary>
        /// Gets or sets solution failure.
        /// </summary>
        public virtual Failure Failure { get; set; } = new Failure();
    }
}
