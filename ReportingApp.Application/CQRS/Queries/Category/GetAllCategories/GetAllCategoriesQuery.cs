using MediatR;
using ReportingApp.Application.DTO;

namespace ReportingApp.Application.CQRS.Queries.Category.GetAllCategories
{
    /// <summary>
    /// Query to get all failure categories.
    /// </summary>
    public class GetAllCategoriesQuery : IRequest<ICollection<FailureCategoryDto>>
    {
    }
}
