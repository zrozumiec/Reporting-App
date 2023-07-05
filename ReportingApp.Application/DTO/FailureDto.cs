using System.ComponentModel;
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
        [DisplayName("Failure name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure location.
        /// </summary>
        public FailureLocationDto Location { get; set; } = new FailureLocationDto();

        /// <summary>
        /// Gets or sets failure status id.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets failure status.
        /// </summary>
        public FailureStatusDto Status { get; set; } = new FailureStatusDto();

        /// <summary>
        /// Gets or sets failure user id.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure user.
        /// </summary>
        public ApplicationUserDto User { get; set; } = new ApplicationUserDto();

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
