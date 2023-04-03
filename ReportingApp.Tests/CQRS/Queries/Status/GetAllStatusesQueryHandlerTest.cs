using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Status.GetAllStatuses;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Status
{
    public class GetAllStatusesQueryHandlerTest
    {
        [Test]
        public async Task GetAllStatusesQuery_Should_Return_All_Statuses()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureStatusRepository>();
            var mapperMock = new Mock<IMapper>();
            var queryHandler = new GetAllStatusesQueryHandler(repositoryMock.Object, mapperMock.Object);
            var query = new GetAllStatusesQuery();
            var expectedResult = new List<FailureStatusDto>();
            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(It.IsAny<List<FailureStatus>>());
            mapperMock.Setup(x => x.Map<ICollection<FailureStatusDto>>(It.IsAny<List<FailureStatus>>())).Returns(expectedResult);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
            repositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
        }
    }
}
