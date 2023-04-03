using FluentValidation;

namespace ReportingApp.Application.CQRS.Commands.Location.CreateLocation
{
    /// <summary>
    /// Validator rules for create failure location command.
    /// </summary>
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLocationCommandValidator"/> class.
        /// </summary>
        public CreateLocationCommandValidator()
        {
            this.RuleFor(x => x.City)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            this.RuleFor(x => x.Country)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            this.RuleFor(x => x.Factory)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            this.RuleFor(x => x.Machine)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            this.RuleFor(x => x.Street)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            this.RuleFor(x => x.Description)
                .MaximumLength(300);
        }
    }
}
