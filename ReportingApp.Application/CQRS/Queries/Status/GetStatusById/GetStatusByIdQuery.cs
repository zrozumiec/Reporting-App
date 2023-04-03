using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Status.GetStatusById
{
    /// <summary>
    /// Query to get failure status by id.
    /// </summary>
    public class GetStatusByIdQuery : IRequest<FailureStatusDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetStatusByIdQuery"/> class.
        /// </summary>
        /// <param name="id">Status id.</param>
        public GetStatusByIdQuery(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets status id.
        /// </summary>
        public int Id { get; }
    }
}
