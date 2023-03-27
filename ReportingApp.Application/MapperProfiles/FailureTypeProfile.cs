using AutoMapper;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// Failure type mapper profile.
    /// </summary>
    public class FailureTypeProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureTypeProfile"/> class.
        /// </summary>
        public FailureTypeProfile()
        {
            this.CreateMap<FailureType, FailureTypeDto>()
                .ReverseMap();
        }
    }
}
