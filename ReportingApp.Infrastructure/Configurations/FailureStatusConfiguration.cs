using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure.Configurations
{
    /// <inheritdoc/>
    public class FailureStatusConfiguration : IEntityTypeConfiguration<FailureStatus>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FailureStatus> p)
        {
            p.Property(x => x.Name).IsRequired().HasMaxLength(150);

            p.HasMany(x => x.Failures).WithOne(x => x.Status).HasForeignKey(x => x.StatusId);

            p.HasData(
                new FailureStatus() { Id = 1, Name = "New" },
                new FailureStatus() { Id = 2, Name = "Reserved" },
                new FailureStatus() { Id = 3, Name = "In progress" },
                new FailureStatus() { Id = 4, Name = "Done" });
        }
    }
}
