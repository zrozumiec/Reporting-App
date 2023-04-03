using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Commands.Category.CreateCategory;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Category
{
    public class CreateCategoryCommandHandlerTest
    {
        [Test]
        public async Task CreateCategoryCommand_Should_Create_Category_And_Return_Id()
        {
            // Arrange
            var repositoryMock = new Mock<IFailureCategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            var command = new CreateCategoryCommand()
            {
                Id = 1,
                Name = "Category 1"
            };

            repositoryMock.Setup(x => x.AddAsync(It.IsAny<FailureCategory>())).ReturnsAsync(command.Id);

            var handler = new CreateCategoryCommandHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.That(command.Id, Is.EqualTo(result));
            repositoryMock.Verify(x => x.AddAsync(It.IsAny<FailureCategory>()), Times.Once);
        }
    }
}
