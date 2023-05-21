using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure.
    /// </summary>
    public class FailureDto : BaseDto
    {
        /// <summary>
        /// Gets or sets failure name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure location.
        /// </summary>
        public FailureLocationDto Location { get; set; } = new ();

        /// <summary>
        /// Gets or sets failure status.
        /// </summary>
        public FailureStatusDto StatusName { get; set; } = new ();

        /// <summary>
        /// Gets or sets failure user.
        /// </summary>
        public ApplicationUserDto User { get; set; } = new ();

        /// <summary>
        /// Gets or sets failure types.
        /// </summary>
        public ICollection<FailureTypeDto> FailureTypes { get; set; } = new List<FailureTypeDto>();

        /// <summary>
        /// Gets or sets failure solutions.
        /// </summary>
        public ICollection<FailureSolutionDto> FailureSolutions { get; set; } = new List<FailureSolutionDto>();

        /// <summary>
        /// Gets or sets a value indicating whether any solution is accepted.
        /// </summary>
        [DisplayName("Solution accepted")]
        public bool AnySolutionAccepted { get; set; }
    }
}
