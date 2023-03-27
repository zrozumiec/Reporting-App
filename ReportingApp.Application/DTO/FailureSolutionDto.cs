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
        /// Gets or sets a value indicating whether solution is accepted.
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Gets or sets solution user.
        /// </summary>
        public ApplicationUserDto User { get; set; } = new ();

        /// <summary>
        /// Gets or sets solution failure.
        /// </summary>
        public FailureDto Failure { get; set; } = new ();
    }
}
