using ReportingApp.Domain.Entities.Base;

namespace ReportingApp.Domain.Entities
{
    /// <summary>
    /// Class represents failure category.
    /// </summary>
    public class FailureCategory : BaseEntity
    {
        /// <summary>
        /// Gets or sets failure category name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure types.
        /// </summary>
        public virtual ICollection<FailureType> FailureTypes { get; set; } = new List<FailureType>();
    }
}
