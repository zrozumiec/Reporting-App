using FluentValidation;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Status.EditStatus
{
    /// <summary>
    /// Validator rules for edit failure status command.
    /// </summary>
    public class EditStatusCommandValidator : AbstractValidator<EditStatusCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditStatusCommandValidator"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        public EditStatusCommandValidator(IFailureStatusRepository repository)
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Custom((value, context) =>
                {
                    var statusInDatabase = repository.GetByNameAsync(value).Result;

                    if (statusInDatabase is not null)
                    {
                        context.AddFailure($"Status with name: {value}, already exist in database");
                    }
                });
        }
    }
}
