using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Infrastructure
{
    /// <summary>
    /// Application DbContext.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a DbContext.</param>
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets DbSet failures.
        /// </summary>
        public DbSet<Failure> Failures { get; set; }

        /// <summary>
        /// Gets or sets DbSet failure category.
        /// </summary>
        public DbSet<FailureCategory> FailureCategories { get; set; }

        /// <summary>
        /// Gets or sets DbSet failure location.
        /// </summary>
        public DbSet<FailureLocation> FailureLocations { get; set; }

        /// <summary>
        /// Gets or sets DbSet failure solution.
        /// </summary>
        public DbSet<FailureSolution> FailureSolutions { get; set; }

        /// <summary>
        /// Gets or sets DbSet failure status.
        /// </summary>
        public DbSet<FailureStatus> FailureStatuses { get; set; }

        /// <summary>
        /// Gets or sets DbSet failure type.
        /// </summary>
        public DbSet<FailureType> FailureTypes { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
