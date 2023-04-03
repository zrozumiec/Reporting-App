using FluentValidation;

namespace ReportingApp.Application.CQRS.Commands.Location.EditLocation
{
    /// <summary>
    /// Validator rules for edit failure location command.
    /// </summary>
    public class EditLocationCommandValidator : AbstractValidator<EditLocationCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditLocationCommandValidator"/> class.
        /// </summary>
        public EditLocationCommandValidator()
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
