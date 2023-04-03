using AutoMapper;
using ReportingApp.Application.CQRS.Commands.Status.CreateStatus;
using ReportingApp.Application.CQRS.Commands.Status.EditStatus;
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
            this.CreateMap<CreateStatusCommand, FailureStatus>();
            this.CreateMap<EditStatusCommand, FailureStatus>();
            this.CreateMap<FailureStatusDto, EditStatusCommand>();
        }
    }
}
