using AutoMapper;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// App user mapper profile.
    /// </summary>
    public class ApplicationUserProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserProfile"/> class.
        /// </summary>
        public ApplicationUserProfile()
        {
            this.CreateMap<ApplicationUser, ApplicationUserDto>()
                .ReverseMap();
        }
    }
}
