using FluentValidation;

namespace ReportingApp.Application.CQRS.Commands.Failure.CreateFailuire
{
    /// <summary>
    /// Validator rules for create failure command.
    /// </summary>
    public class CreateFailureCommandValidator : AbstractValidator<CreateFailureCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFailureCommandValidator"/> class.
        /// </summary>
        public CreateFailureCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            RuleFor(x => x.Location.City)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Location.Country)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Location.Factory)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Location.Machine)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Location.Street)
                .NotEmpty()
                .NotNull();
        }
    }
}
