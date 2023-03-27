using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure status.
    /// </summary>
    public class FailureStatusDto : BaseDto
    {
        /// <summary>
        /// Gets or sets failure status name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure with specify statuses.
        /// </summary>
        public ICollection<FailureDto> Failures { get; set; } = new List<FailureDto>();
    }
}
