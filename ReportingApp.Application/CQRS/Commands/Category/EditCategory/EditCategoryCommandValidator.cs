using FluentValidation;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Category.EditCategory
{
    /// <summary>
    /// Validator rules for edit failure category command.
    /// </summary>
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditCategoryCommandValidator"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        public EditCategoryCommandValidator(IFailureCategoryRepository repository)
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .Custom((value, context) =>
                {
                    var categoryInDatabase = repository.GetByNameAsync(value).Result;

                    if (categoryInDatabase is not null)
                    {
                        context.AddFailure($"Category with name: {value}, already exist in database");
                    }
                });
        }
    }
}
