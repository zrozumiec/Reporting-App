using Moq;
using ReportingApp.Application.CQRS.Commands.Status.DeleteStatus;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Status
{
    public class DeleteStatusCommandHandlerTest
    {
        [Test]
        public async Task DeleteStatusCommand_Should_Delete_Status_And_Return_Id()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureStatusRepository>();
            repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(1);
            var command = new DeleteStatusCommand(1);
            var handler = new DeleteStatusCommandHandler(repositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(command.Id, Is.EqualTo(result));
            repositoryMock.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
