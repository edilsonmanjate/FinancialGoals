using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByUserIdQuery;

public class GetFinancialGoalsByUserIdQuery : IRequest<BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    public Guid UserId { get; set; }

}
