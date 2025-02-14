using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByIdealMonthAmountQuery;

public class GetFinancialGoalsByIdealMonthAmountQuery : IRequest<BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    public decimal IdealMonthAmount { get; set; }

}