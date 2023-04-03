using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Category.GetCategoryByName;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Status
{
    public class GetStatusByNameQueryHandlerTest
    {
        [Test]
        public async Task GetStatusByNameQuery_Should_Return_StatusDto()
        {
            // Arrange
            var query = new GetStatusByNameQuery("Test");
            var repositoryMock = new Mock<IFailureStatusRepository>();
            var mapperMock = new Mock<IMapper>();
            var handler = new GetStatusByNameQueryHandler(repositoryMock.Object, mapperMock.Object);
            var expectedResult = new FailureStatusDto();
            repositoryMock.Setup(x => x.GetByNameAsync(query.Name)).ReturnsAsync(new FailureStatus());
            mapperMock.Setup(x => x.Map<FailureStatusDto>(It.IsAny<FailureStatus>())).Returns(expectedResult);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
            repositoryMock.Verify(x => x.GetByNameAsync(query.Name), Times.Once);
        }
    }
}
