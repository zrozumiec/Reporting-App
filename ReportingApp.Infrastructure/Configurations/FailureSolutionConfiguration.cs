using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure.Configurations
{
    /// <inheritdoc/>
    public class FailureSolutionConfiguration : IEntityTypeConfiguration<FailureSolution>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FailureSolution> p)
        {
            p.Property(x => x.Accepted).IsRequired().HasDefaultValue(false);
            p.Property(x => x.Description).HasMaxLength(300);
            p.Property(x => x.ExpectedCostMin).IsRequired().HasDefaultValue(0.0M);
            p.Property(x => x.ExpectedCostMax).IsRequired().HasDefaultValue(0.0M);

            p.HasOne(x => x.User).WithMany(x => x.Solutions).HasForeignKey(x => x.UserId);
            p.HasOne(x => x.Failure)
                .WithMany(x => x.FailureSolutions)
                .HasForeignKey(x => x.FailureId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
