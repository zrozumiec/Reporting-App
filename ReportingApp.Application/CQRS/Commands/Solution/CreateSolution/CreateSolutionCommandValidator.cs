using FluentValidation;

namespace ReportingApp.Application.CQRS.Commands.Solution.CreateSolution
{
    public class CreateSolutionCommandValidator : AbstractValidator<CreateSolutionCommand>
    {
        public CreateSolutionCommandValidator()
        {
            this.RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            this.RuleFor(x => x.ExpectedCostMin)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .LessThanOrEqualTo(x => x.ExpectedCostMax);

            this.RuleFor(x => x.ExpectedCostMax)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .GreaterThanOrEqualTo(x => x.ExpectedCostMin);

            this.RuleFor(x => x.ExpectedStartTime)
                .LessThanOrEqualTo(x => x.ExpectedEndTime);

            this.RuleFor(x => x.ExpectedEndTime)
                .GreaterThanOrEqualTo(x => x.ExpectedStartTime);
        }
    }
}
