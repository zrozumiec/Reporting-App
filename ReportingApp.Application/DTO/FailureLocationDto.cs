using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure location.
    /// </summary>
    public class FailureLocationDto : BaseDto
    {
        /// <summary>
        /// Gets or sets location street.
        /// </summary>
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets location city.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets location country.
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets location factory.
        /// </summary>
        public string Factory { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets location machine.
        /// </summary>
        public string Machine { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets location description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets location failures.
        /// </summary>
        public ICollection<FailureDto> Failures { get; set; } = new List<FailureDto>();
    }
}
