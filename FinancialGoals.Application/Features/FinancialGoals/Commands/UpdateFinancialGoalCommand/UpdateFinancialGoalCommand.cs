using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Core.Enums;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Commands.UpdateFinancialGoalCommand;

public class UpdateFinancialGoalCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Target { get; set; }
    public DateOnly DueDate { get; set; }
    public decimal IdealMonthlyAmount { get; set; }
    public Status Status { get; set; }
    public Guid UserId { get; set; }
}