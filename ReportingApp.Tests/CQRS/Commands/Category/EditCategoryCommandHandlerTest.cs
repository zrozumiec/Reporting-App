using AutoMapper;
using Moq;
using ReportingApp.Application.CQRS.Commands.Category.EditCategory;
using ReportingApp.Domain.Entities;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Category
{
    public class EditCategoryCommandHandlerTest
    {
        [Test]
        public async Task EditCategoryCommand_Should_Update_Category_And_Return_Id()
        {
            // Arrange
            var command = new EditCategoryCommand { Id = 1, Name = "Test_Update" };
            var category = new FailureCategory { Id = 1, Name = "Test" };
            var repositoryMock = new Mock<IFailureCategoryRepository>();
            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<FailureCategory>()))
                .ReturnsAsync(1);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<FailureCategory>(It.IsAny<EditCategoryCommand>()))
                .Returns(category);
            var handler = new EditCategoryCommandHandler(repositoryMock.Object, mapperMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(1));
            repositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<FailureCategory>()), Times.Once);
        }
    }
}
