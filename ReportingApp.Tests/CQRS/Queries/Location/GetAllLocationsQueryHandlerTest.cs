using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Location.GetAllLocation;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Location
{
    public class GetAllLocationsQueryHandlerTest
    {
        [Test]
        public async Task GetAllLocationsQuery_Should_Return_Correct_Number_Of_Locations()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureLocationRepository>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestLocations());
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<ICollection<FailureLocationDto>>(It.IsAny<ICollection<FailureLocation>>())).Returns(GetTestLocationDtos());
            var handler = new GetAllLocationsQueryHandler(repositoryMock.Object, mapperMock.Object);
            var query = new GetAllLocationsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(GetTestLocations(), Has.Count.EqualTo(result.Count));
            repositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllLocationsQuery_Should_Return_Correct_LocationDtos()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureLocationRepository>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(GetTestLocations());
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<ICollection<FailureLocationDto>>(It.IsAny<ICollection<FailureLocation>>())).Returns(GetTestLocationDtos());
            var handler = new GetAllLocationsQueryHandler(repositoryMock.Object, mapperMock.Object);
            var query = new GetAllLocationsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(GetTestLocations().First().Id, Is.EqualTo(result.First().Id));
                Assert.That(GetTestLocations().First().Street, Is.EqualTo(result.First().Street));
                Assert.That(GetTestLocations().Last().Id, Is.EqualTo(result.Last().Id));
                Assert.That(GetTestLocations().Last().Street, Is.EqualTo(result.Last().Street));
            });
            repositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        private static ICollection<FailureLocation> GetTestLocations()
        {
            return new List<FailureLocation>
            {
                new FailureLocation { Id = 1, Street = "Test Location 1" },
                new FailureLocation { Id = 2, Street = "Test Location 2" }
            };
        }

        private static ICollection<FailureLocationDto> GetTestLocationDtos()
        {
            return new List<FailureLocationDto>
            {
                new FailureLocationDto { Id = 1, Street = "Test Location 1" },
                new FailureLocationDto { Id = 2, Street = "Test Location 2" }
            };
        }
    }
}
