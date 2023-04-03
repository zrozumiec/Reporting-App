using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Location.GetLocationById;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Location
{
    public class GetLocationByIdQueryHandlerTest
    {
        [Test]
        public async Task GetLocationByIdQuery_Returns_FailureLocationDto()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureLocationRepository>();
            var mapperMock = new Mock<IMapper>();
            var query = new GetLocationQuery(1);
            var expectedResult = new FailureLocationDto();
            repositoryMock.Setup(x => x.GetByIdAsync(query.LocationId)).ReturnsAsync(new FailureLocation());
            mapperMock.Setup(x => x.Map<FailureLocationDto>(It.IsAny<FailureLocation>())).Returns(expectedResult);
            var handler = new GetLocationQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }
    }
}
