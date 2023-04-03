using FluentValidation;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Category.CreateCategory
{
    /// <summary>
    /// Validator rules for create failure category command.
    /// </summary>
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryCommandValidator"/> class.
        /// </summary>
        /// <param name="repository">Failure category repository.</param>
        public CreateCategoryCommandValidator(IFailureCategoryRepository repository)
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
