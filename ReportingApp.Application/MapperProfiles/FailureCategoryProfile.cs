using AutoMapper;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// Failure category mapper profile.
    /// </summary>
    public class FailureCategoryProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureCategoryProfile"/> class.
        /// </summary>
        public FailureCategoryProfile()
        {
            this.CreateMap<FailureCategory, FailureCategoryDto>()
                .ReverseMap();
        }
    }
}
