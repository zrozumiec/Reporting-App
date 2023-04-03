using MediatR;

namespace ReportingApp.Application.CQRS.Commands.Location.DeleteLocation
{
    /// <summary>
    /// Command to delete location.
    /// </summary>
    public class DeleteLocationCommand : IRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLocationCommand"/> class.
        /// </summary>
        /// <param name="id">Location id to delete.</param>
        public DeleteLocationCommand(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets location id to delete.
        /// </summary>
        public int Id { get; }
    }
}
