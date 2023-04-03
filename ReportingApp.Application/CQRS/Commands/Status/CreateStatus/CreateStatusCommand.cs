using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Status.CreateStatus
{
    /// <summary>
    /// Command to create new failure status.
    /// </summary>
    public class CreateStatusCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets status id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets status name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
