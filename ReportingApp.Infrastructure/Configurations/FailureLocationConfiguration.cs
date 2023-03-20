using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure.Configurations
{
    /// <inheritdoc/>
    public class FailureLocationConfiguration : IEntityTypeConfiguration<FailureLocation>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FailureLocation> p)
        {
            p.Property(x => x.Street).IsRequired().HasMaxLength(150);
            p.Property(x => x.City).IsRequired().HasMaxLength(150);
            p.Property(x => x.Country).IsRequired().HasMaxLength(150);
            p.Property(x => x.Factory).IsRequired().HasMaxLength(150);
            p.Property(x => x.Machine).IsRequired().HasMaxLength(150);
            p.Property(x => x.Description).HasMaxLength(300);

            p.HasMany(x => x.Failures).WithOne(x => x.Location).HasForeignKey(x => x.LocationId);
        }
    }
}
