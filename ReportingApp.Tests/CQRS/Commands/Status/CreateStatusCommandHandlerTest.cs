using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Commands.Status.CreateStatus;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Status
{
    public class CreateStatusCommandHandlerTest
    {
        [Test]
        public async Task CreateStatusCommand_Should_Create_Status_And_Returns_Id()
        {
            // Arrange
            var request = new CreateStatusCommand()
            {
                Id = 1,
                Name = "Test"
            };
            var repositoryMock = new Mock<IFailureStatusRepository>();
            repositoryMock.Setup(x => x.AddAsync(It.IsAny<FailureStatus>())).ReturnsAsync(1);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<FailureStatus>(It.IsAny<CreateStatusCommand>())).Returns(new FailureStatus());
            var handler = new CreateStatusCommandHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.That(request.Id, Is.EqualTo(result));
            repositoryMock.Verify(x => x.AddAsync(It.IsAny<FailureStatus>()), Times.Once);
        }
    }
}
