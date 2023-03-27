using AutoMapper;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// Failure status mapper profile.
    /// </summary>
    public class FailureStatusProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureStatusProfile"/> class.
        /// </summary>
        public FailureStatusProfile()
        {
            this.CreateMap<FailureStatus, FailureStatusDto>()
                .ReverseMap();
        }
    }
}
