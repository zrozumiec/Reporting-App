using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Location.GetLocationById
{
    /// <summary>
    /// Query to get specified location.
    /// </summary>
    public class GetLocationQuery : IRequest<FailureLocationDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLocationQuery"/> class.
        /// </summary>
        /// <param name="locationId">Location id.</param>
        public GetLocationQuery(int locationId)
        {
            this.LocationId = locationId;
        }

        /// <summary>
        /// Gets location id.
        /// </summary>
        public int LocationId { get; }
    }
}
