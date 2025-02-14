using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByTargetQuery;

public class GetFinancialGoalsByTargetQuery : IRequest<BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    public decimal Target { get; set; }

}
