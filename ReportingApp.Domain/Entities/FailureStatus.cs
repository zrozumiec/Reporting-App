using ReportingApp.Domain.Entities.Base;

namespace ReportingApp.Domain.Entities
{
    /// <summary>
    /// Class represents failure status.
    /// </summary>
    public class FailureStatus : BaseEntity
    {
        /// <summary>
        /// Gets or sets failure status name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure with specify statuses.
        /// </summary>
        public virtual ICollection<Failure> Failures { get; set; } = new List<Failure>();
    }
}
