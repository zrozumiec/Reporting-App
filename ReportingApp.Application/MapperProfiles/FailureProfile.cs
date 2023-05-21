using AutoMapper;
using ReportingApp.Application.CQRS.Commands.Failure.EditFailure;
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
                .ForMember(x => x.AnySolutionAccepted, o => o.MapFrom(x => x.FailureSolutions.Any(x => x.Accepted)))
                .ReverseMap();

            this.CreateMap<EditFailureCommand, Failure>();
        }
    }
}
