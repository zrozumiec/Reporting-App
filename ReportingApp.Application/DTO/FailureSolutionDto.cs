using System.ComponentModel;
using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure solution.
    /// </summary>
    public class FailureSolutionDto : BaseDto
    {
        /// <summary>
        /// Gets or sets solution description.
        /// </summary>
        [DisplayName("Solution description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets solution expected min cost.
        /// </summary>
        [DisplayName("Expected cost min")]
        public decimal ExpectedCostMin { get; set; }

        /// <summary>
        /// Gets or sets solution expected max cost.
        /// </summary>
        [DisplayName("Expected cost max")]
        public decimal ExpectedCostMax { get; set; }

        /// <summary>
        /// Gets or sets solution expected start time.
        /// </summary>
        [DisplayName("Expected start time")]
        public DateTimeOffset ExpectedStartTime { get; set; }
        /// <summary>
        /// Gets or sets solution expected end time.
        /// </summary>
        [DisplayName("Expected end time")]
        public DateTimeOffset ExpectedEndTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether solution is accepted.
        /// </summary>
        [DisplayName("Solution accepted")]
        public bool Accepted { get; set; }

        /// <summary>
        /// Gets or sets solution user id.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets solution user.
        /// </summary>
        public ApplicationUserDto User { get; set; } = new ApplicationUserDto();

        /// <summary>
        /// Gets or sets solution failure id.
        /// </summary>
        public int FailureId { get; set; }

        /// <summary>
        /// Gets or sets solution failure.
        /// </summary>
        public FailureDto Failure { get; set; } = new FailureDto();
    }
}
