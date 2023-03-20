using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure.Configurations
{
    /// <inheritdoc/>
    public class FailureConfigure : IEntityTypeConfiguration<Failure>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Failure> p)
        {
            p.Property(x => x.Name).IsRequired().HasMaxLength(150);

            p.HasOne(x => x.User).WithMany(x => x.Failures).HasForeignKey(x => x.UserId);
            p.HasOne(x => x.Status).WithMany(x => x.Failures).HasForeignKey(x => x.StatusId);
            p.HasOne(x => x.Location).WithMany(x => x.Failures).HasForeignKey(x => x.LocationId);
            p.HasMany(x => x.FailureTypes).WithMany(x => x.Failures);
            p.HasMany(x => x.FailureSolutions)
                .WithOne(x => x.Failure)
                .HasForeignKey(x => x.FailureId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
