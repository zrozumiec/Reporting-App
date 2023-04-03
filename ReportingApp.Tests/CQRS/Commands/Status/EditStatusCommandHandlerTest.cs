using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Commands.Status.EditStatus;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Status
{
    public class EditStatusCommandHandlerTest
    {
        [Test]
        public async Task EditStatusCommand_Should_Edit_Status_And_Return_Id()
        {
            // Arrange
            var request = new EditStatusCommand()
            {
                Id = 1, Name = "Test"
            };
            var status = new FailureStatus()
            {
                Id = 1,
                Name = "Test"
            };
            var mapperMock = new Mock<IMapper>();
            var repositoryMock = new Mock<IFailureStatusRepository>();
            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<FailureStatus>()))
                .ReturnsAsync(1);
            var handler = new EditStatusCommandHandler(repositoryMock.Object, mapperMock.Object);
            mapperMock.Setup(x => x.Map<FailureStatus>(It.IsAny<EditStatusCommand>()))
                .Returns(status);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(request.Id, Is.EqualTo(result));
            repositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<FailureStatus>()), Times.Once);
        }
    }
}
