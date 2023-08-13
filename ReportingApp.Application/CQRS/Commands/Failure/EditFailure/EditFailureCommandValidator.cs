using FluentValidation;

namespace ReportingApp.Application.CQRS.Commands.Failure.EditFailure
{
    public class EditFailureCommandValidator : AbstractValidator<EditFailureCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditFailureCommandValidator"/> class.
        /// </summary>
        public EditFailureCommandValidator()
        {
            RuleFor(x => x.Failure.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            RuleFor(x => x.Failure.Location.City)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Failure.Location.Country)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Failure.Location.Factory)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Failure.Location.Machine)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Failure.Location.Street)
                .NotEmpty()
                .NotNull();
        }
    }
}
