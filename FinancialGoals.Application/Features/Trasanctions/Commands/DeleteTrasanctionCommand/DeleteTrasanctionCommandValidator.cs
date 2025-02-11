using FluentValidation;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.DeleteTrasanctionCommand;

public class DeleteTrasanctionCommandValidator : AbstractValidator<DeleteTrasanctionCommand>
{
    public DeleteTrasanctionCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required")
           .NotNull().WithMessage("Id is required");
    }
}
