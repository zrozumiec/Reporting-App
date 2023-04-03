using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Status.DeleteStatus
{
    /// <summary>
    /// Command to delete failure status.
    /// </summary>
    public class DeleteStatusCommand : IRequest<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStatusCommand"/> class.
        /// </summary>
        /// <param name="id">Status id to delete.</param>
        public DeleteStatusCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets status id to delete.
        /// </summary>
        public int Id { get; }
    }
}
