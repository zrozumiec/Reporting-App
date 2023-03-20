using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure.Configurations
{
    /// <inheritdoc/>
    public class FailureCategoryConfiguration : IEntityTypeConfiguration<FailureCategory>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<FailureCategory> p)
        {
            p.Property(x => x.Name).IsRequired().HasMaxLength(150);

            p.HasMany(x => x.FailureTypes).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            p.HasData(
                new FailureCategory() { Id = 1, Name = "Electric" },
                new FailureCategory() { Id = 2, Name = "Mechanic" },
                new FailureCategory() { Id = 3, Name = "Pneumatic" },
                new FailureCategory() { Id = 4, Name = "SoftwarePLC" },
                new FailureCategory() { Id = 5, Name = "Robotic" },
                new FailureCategory() { Id = 6, Name = "Other" });
        }
    }
}
