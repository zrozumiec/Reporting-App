using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Category.GetCategoryByName;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Category
{
    public class GetCategoryByNameQueryHandlerTest
    {
        [Test]
        public async Task GetCategoryByNameQuery_Should_Return_CategoryDto()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureCategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            var query = new GetCategoryByNameQuery("Test");
            var expectedResult = new FailureCategoryDto()
            {
                Id = 1,
                Name = "Test",
            };
            repositoryMock.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ReturnsAsync(new FailureCategory()
            {
                Id = 1,
                Name = "Test",
            });
            mapperMock.Setup(x => x.Map<FailureCategoryDto>(It.IsAny<FailureCategory>())).Returns(expectedResult);
            var handler = new GetCategoryByNameQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(result));
            repositoryMock.Verify(x => x.GetByNameAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
