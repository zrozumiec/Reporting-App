using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Failure.GetAllUserFailures
{
    public class GetAllUserFailuresQuery : IRequest<ICollection<FailureDto>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserFailuresQuery"/> class.
        /// </summary>
        /// <param name="userId">User id.</param>
        public GetAllUserFailuresQuery(string userId)
        {
            this.UserId = userId;
        }

        /// <summary>
        /// Gets User id.
        /// </summary>
        public string UserId { get; }
    }
}
