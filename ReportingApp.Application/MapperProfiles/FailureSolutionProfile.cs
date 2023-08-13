using AutoMapper;
using ReportingApp.Application.CQRS.Commands.Solution.EditSolution;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;

namespace ReportingApp.Application.MapperProfiles
{
    /// <summary>
    /// Failure solution mapper profile.
    /// </summary>
    public class FailureSolutionProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureSolutionProfile"/> class.
        /// </summary>
        public FailureSolutionProfile()
        {
            this.CreateMap<FailureSolution, FailureSolutionDto>()
                .ReverseMap();
            this.CreateMap<FailureSolutionDto, EditSolutionCommand>();
        }
    }
}
