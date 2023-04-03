using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Commands.Location.EditLocation;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Location
{
    public class EditLocationCommandHandlerTest
    {
        [Test]
        public async Task EditLocationCommand_Should_Update_Location()
        {
            // Arrange
            var request = new EditLocationCommand()
            {
                Id = 1,
                Country = "Test Location"
            };
            var repositoryMock = new Mock<IFailureLocationRepository>();
            var mapperMock = new Mock<IMapper>();
            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<FailureLocation>()));
            var handler = new EditLocationCommandHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            repositoryMock.Verify(x => x.UpdateAsync(request.Id, It.IsAny<FailureLocation>()), Times.Once);
        }
    }
}
