using AutoMapper;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// Failure location mapper profile.
    /// </summary>
    public class FailureLocationProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureLocationProfile"/> class.
        /// </summary>
        public FailureLocationProfile()
        {
            this.CreateMap<FailureLocation, FailureLocationDto>()
                .ReverseMap();
        }
    }
}
