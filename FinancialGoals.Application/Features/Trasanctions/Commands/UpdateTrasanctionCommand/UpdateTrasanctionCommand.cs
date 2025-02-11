using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Core.Enums;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.UpdateTrasanctionCommand;

public class UpdateTrasanctionCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
    public decimal Quantity { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid FinancialGoalId { get; private set; }
    public Guid UserId { get; set; }
}
