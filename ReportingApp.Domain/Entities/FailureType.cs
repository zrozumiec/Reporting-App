using ReportingApp.Domain.Entities.Base;

namespace ReportingApp.Domain.Entities
{
    /// <summary>
    /// Class represents failure type.
    /// </summary>
    public class FailureType : BaseEntity
    {
        /// <summary>
        /// Gets or sets failure type description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets failure category.
        /// </summary>
        public virtual FailureCategory Category { get; set; } = new ();

        /// <summary>
        /// Gets or sets failure of specified type.
        /// </summary>
        public virtual ICollection<Failure> Failures { get; set; } = new List<Failure>();
    }
}
