using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure.Configurations
{
    /// <inheritdoc/>
    public class FailureTypeConfiguration : IEntityTypeConfiguration<FailureType>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FailureType> p)
        {
            p.Property(x => x.Description).HasMaxLength(300);

            p.HasOne(x => x.Category).WithMany(x => x.FailureTypes).HasForeignKey(x => x.CategoryId);
            p.HasMany(x => x.Failures).WithMany(x => x.FailureTypes);
        }
    }
}
