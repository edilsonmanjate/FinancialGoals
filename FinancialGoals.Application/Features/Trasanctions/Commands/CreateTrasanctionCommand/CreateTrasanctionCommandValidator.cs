using FluentValidation;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.CreateTrasanctionCommand;

public class CreateTrasanctionCommandValidator : AbstractValidator<CreateTrasanctionCommand>
{
    public CreateTrasanctionCommandValidator()
    {
        RuleFor(d => d.Id)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull().WithMessage("I{PropertyName}d is required");

        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.TransactionType)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName}  is required");


        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required");


        RuleFor(x => x.FinancialGoalId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required");



        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required")
           .NotNull().WithMessage("{PropertyName} is required");

    }
}
