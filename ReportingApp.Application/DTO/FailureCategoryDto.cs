using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure category.
    /// </summary>
    public class FailureCategoryDto : BaseDto
    {
        /// <summary>
        /// Gets or sets failure category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure types description.
        /// </summary>
        public ICollection<FailureTypeDto> FailureTypes { get; set; } = new List<FailureTypeDto>();
    }
}
