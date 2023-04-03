using Moq;
using ReportingApp.Application.CQRS.Commands.Category.DeleteCategory;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Tests.CQRS.Commands.Category
{
    public class DeleteCategoryCommandHandlerTest
    {
        [Test]
        public async Task DeleteCategoryCommand_Should_Delete_Category_And_Return_Id()
        {
            // Arrange
            var mockRepository = new Mock<IFailureCategoryRepository>();
            mockRepository.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(5);
            var handler = new DeleteCategoryCommandHandler(mockRepository.Object);
            var command = new DeleteCategoryCommand(5);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(5));
            mockRepository.Verify(x => x.DeleteAsync(command.Id), Times.Once);
        }
    }
}