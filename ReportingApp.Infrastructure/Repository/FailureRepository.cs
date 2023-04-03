﻿using Microsoft.EntityFrameworkCore;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository.Base;

namespace ReportingApp.Infrastructure.Repository
{
    /// <summary>
    /// Class represents failure repository.
    /// </summary>
    public class FailureRepository : BaseRepository<Failure>, IFailureRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Application db context.</param>
        public FailureRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc/>
        protected override DbSet<Failure> DbSet => this.DbContext.Failures;

        /// <inheritdoc/>
        public override async Task<int> UpdateAsync(int id, Failure newItem)
        {
            var failure = await this.DbSet.FindAsync(id);

            if (failure is null)
            {
                throw new ArgumentException("Failure with given id does not exist in database.");
            }

            failure.Name = newItem.Name;
            failure.StatusId = newItem.StatusId;
            failure.LocationId = newItem.LocationId;

            await this.SaveAsync();

            return failure.Id;
        }
    }
}