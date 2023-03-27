using AutoMapper;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// Failure mapper profile.
    /// </summary>
    public class FailureProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureProfile"/> class.
        /// </summary>
        public FailureProfile()
        {
            this.CreateMap<Failure, FailureDto>()
                .ReverseMap();
        }
    }
}
