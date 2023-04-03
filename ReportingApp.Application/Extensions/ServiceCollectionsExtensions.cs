using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ReportingApp.Application.CQRS.Commands.Category.CreateCategory;
using ReportingApp.Application.MapperProfiles;

namespace ReportingApp.Application.Extensions
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
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationUserProfile));
            services.AddAutoMapper(typeof(FailureCategoryProfile));
            services.AddAutoMapper(typeof(FailureLocationProfile));
            services.AddAutoMapper(typeof(FailureProfile));
            services.AddAutoMapper(typeof(FailureSolutionProfile));
            services.AddAutoMapper(typeof(FailureStatusProfile));
            services.AddAutoMapper(typeof(FailureTypeProfile));
        }

        /// <summary>
        /// Inject MediatR to DI service.
        /// </summary>
        /// <param name="services">Extension IServiceCollection.</param>
        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        /// <summary>
        /// Inject FluentValidator to DI service.
        /// </summary>
        /// <param name="services">Extension IServiceCollection.</param>
        public static void RegisterFluentValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
