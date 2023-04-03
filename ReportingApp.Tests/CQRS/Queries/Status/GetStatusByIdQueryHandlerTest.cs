using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Status.GetStatusById;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Status
{
    public class GetStatusByIdQueryHandlerTest
    {
        [Test]
        public async Task GetStatusByIdQuery_Should_Return_StatusDto()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureStatusRepository>();
            var mapperMock = new Mock<IMapper>();
            var query = new GetStatusByIdQuery(1);
            var expectedResult = new FailureStatusDto();
            repositoryMock.Setup(x => x.GetByIdAsync(query.Id)).ReturnsAsync(new FailureStatus());
            mapperMock.Setup(x => x.Map<FailureStatusDto>(It.IsAny<FailureStatus>())).Returns(expectedResult);
            var handler = new GetStatusByIdQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
            repositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once());
        }
    }
}
