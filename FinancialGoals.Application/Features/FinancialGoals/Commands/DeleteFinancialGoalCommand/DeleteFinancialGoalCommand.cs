using FinancialGoals.Application.Common.Bases;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Commands.DeleteFinancialGoalCommand;

public class DeleteFinancialGoalCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
}