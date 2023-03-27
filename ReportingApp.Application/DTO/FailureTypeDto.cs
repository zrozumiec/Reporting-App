using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure type.
    /// </summary>
    public class FailureTypeDto : BaseDto
    {
        /// <summary>
        /// Gets or sets failure type description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure category.
        /// </summary>
        public FailureCategoryDto Category { get; set; } = new ();

        /// <summary>
        /// Gets or sets failure of specified type.
        /// </summary>
        public ICollection<FailureDto> Failures { get; set; } = new List<FailureDto>();
    }
}
