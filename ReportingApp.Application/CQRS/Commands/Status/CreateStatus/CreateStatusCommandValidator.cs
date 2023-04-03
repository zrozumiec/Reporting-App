using FluentValidation;
using ReportingApp.Domain.Interfaces;

namespace ReportingApp.Application.CQRS.Commands.Status.CreateStatus
{
    /// <summary>
    /// Validator rules for create failure status command.
    /// </summary>
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStatusCommandValidator"/> class.
        /// </summary>
        /// <param name="repository">Failure status repository.</param>
        public CreateStatusCommandValidator(IFailureStatusRepository repository)
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
