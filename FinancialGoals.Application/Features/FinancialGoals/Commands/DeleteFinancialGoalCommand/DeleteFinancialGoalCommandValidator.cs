using FluentValidation;

namespace FinancialGoals.Application.Features.FinancialGoals.Commands.DeleteFinancialGoalCommand;

public class DeleteFinancialGoalCommandValidator : AbstractValidator<DeleteFinancialGoalCommand>
{
    public DeleteFinancialGoalCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull().WithMessage("{PropertyName} is required");
    }
}
