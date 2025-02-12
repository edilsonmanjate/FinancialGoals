using FluentValidation;

namespace FinancialGoals.Application.Features.FinancialGoals.Commands.CreateFinancialGoalCommand;

public class CreateFinancialGoalCommandValidator : AbstractValidator<CreateFinancialGoalCommand>
{
    public CreateFinancialGoalCommandValidator()
    {
        RuleFor(d => d.Id)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(d => d.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(d => d.Target)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(d => d.DueDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required");
            //.GreaterThan(DateTime.Now.Date).WithMessage("{PropertyName} must be greater than today.");

        RuleFor(d => d.IdealMonthlyAmount)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(d => d.Status)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required");

        RuleFor(d => d.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} is required");



    }
}
