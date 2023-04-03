using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Queries.Category.GetAllCategories;
using ReportingApp.Application.DTO;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Queries.Category
{
    public class GetAllCategoriesQueryHandlerTest
    {
        [Test]
        public async Task GetAllCategoriesQuery_Should_Return_All_Categories()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureCategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            var categories = new List<FailureCategory>
            {
                new FailureCategory { Id = 1, Name = "Category 1" },
                new FailureCategory { Id = 2, Name = "Category 2" }
            };

            repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);
            var categoriesDto = new List<FailureCategoryDto>
            {
                new FailureCategoryDto { Id = 1, Name = "Category 1" },
                new FailureCategoryDto { Id = 2, Name = "Category 2" }
            };
            mapperMock.Setup(x => x.Map<ICollection<FailureCategoryDto>>(categories)).Returns(categoriesDto);
            var handler = new GetAllCategoriesQueryHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(new GetAllCategoriesQuery(), CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(categoriesDto));
            repositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }
    }
}