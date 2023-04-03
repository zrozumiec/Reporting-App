using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Commands.Location.CreateLocation;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Location
{
    public class CreateLocationCommandHandlerTest
    {
        [Test]
        public async Task CreateLocationCommand_Should_Create_Location()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureLocationRepository>();
            var mapperMock = new Mock<IMapper>();
            repositoryMock.Setup(x => x.AddAsync(It.IsAny<FailureLocation>()));
            var command = new CreateLocationCommand()
            {
                Id = 1,
                Country = "Test Location",
                Description = "Test Location",
                Factory = "Test Location",
                Machine = "Test Location",
                Street = "Test Location",
                City = "Test Location"
            };
            var handler = new CreateLocationCommandHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(x => x.AddAsync(It.IsAny<FailureLocation>()), Times.Once);
        }
    }
}
