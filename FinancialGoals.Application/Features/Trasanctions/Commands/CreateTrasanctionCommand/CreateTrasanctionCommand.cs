using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Core.Enums;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.CreateTrasanctionCommand;

public class CreateTrasanctionCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
    public decimal Quantity { get;  set; }
    public TransactionType TransactionType { get;  set; }
    public DateOnly Date { get;  set; }
    public Guid FinancialGoalId { get;  set; }
    public Guid UserId { get; set; }
    public decimal ActualTotal { get;  set; }
}
