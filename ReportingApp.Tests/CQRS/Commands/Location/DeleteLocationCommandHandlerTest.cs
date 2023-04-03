using Moq;
using ReportingApp.Application.CQRS.Commands.Location.DeleteLocation;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Location
{
    public class DeleteLocationCommandHandlerTest
    {
        [Test]
        public async Task DeleteLocationCommand_Should_Delete_Location()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureLocationRepository>();
            repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>()));
            var command = new DeleteLocationCommand(1);
            var handler = new DeleteLocationCommandHandler(repositoryMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
