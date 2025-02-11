using FluentValidation;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.UpdateTrasanctionCommand
{
    public class UpdateTrasanctionCommandValidator : AbstractValidator<UpdateTrasanctionCommand>
    {
        public UpdateTrasanctionCommandValidator()
        {
            RuleFor(d => d.Id)
         .NotEmpty().WithMessage("Id is required.")
         .NotNull().WithMessage("Id is required");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.TransactionType)
                .NotEmpty().WithMessage("Transaction type is required")
                .NotNull().WithMessage("Transaction type is required");


            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required")
                .NotNull().WithMessage("Date is required");


            RuleFor(x => x.FinancialGoalId)
                .NotEmpty().WithMessage("Financial goal is required")
                .NotNull().WithMessage("Financial goal is required");



            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required")
               .NotNull().WithMessage("User is required");
        }

    }
}
