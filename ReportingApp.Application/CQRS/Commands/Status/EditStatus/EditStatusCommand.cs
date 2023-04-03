using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Status.EditStatus
{
    /// <summary>
    /// Command to edit failure status.
    /// </summary>
    public class EditStatusCommand : IRequest<int>
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
