using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Category.GetCategoryById;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Category
{
    public class GetCategoryByIdQueryHandlerTest
    {
        [Test]
        public async Task GetCategoryByIdQuery_Should_Return_CategoryDto()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureCategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            var query = new GetCategoryByIdQuery(1);
            var expectedCategoryDto = new FailureCategoryDto()
            {
                Id = 1,
                Name = "Test",
            };
            repositoryMock.Setup(x => x.GetByIdAsync(query.Id)).ReturnsAsync(new FailureCategory()
            {
                Id = 1,
                Name = "Test",
            });
            mapperMock.Setup(x => x.Map<FailureCategoryDto>(It.IsAny<FailureCategory>())).Returns(expectedCategoryDto);
            var handler = new GetCategoryByIdQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCategoryDto));
            repositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
