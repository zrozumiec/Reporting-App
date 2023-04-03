using Microsoft.Extensions.DependencyInjection;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;
using ReportingApp.Infrastructure.Repository;

namespace ReportingApp.Infrastructure.Extensions
{
    /// <summary>
    /// Static class contains extensions method to configuration DI services.
    /// </summary>
    public static class ServiceCollectionsExtensions
    {
        /// <summary>
        /// Inject AutoMapper profiles to DI service.
        /// </summary>
        /// <param name="services">Extension IServiceCollection.</param>
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFailureCategoryRepository, FailureCategoryRepository>();
            services.AddScoped<IFailureLocationRepository, FailureLocationRepository>();
            services.AddScoped<IFailureRepository, FailureRepository>();
            services.AddScoped<IFailureSolutionRepository, FailureSolutionRepository>();
            services.AddScoped<IFailureStatusRepository, FailureStatusRepository>();
            services.AddScoped<IFailureTypeRepository, FailureTypeRepository>();
        }
    }
}
