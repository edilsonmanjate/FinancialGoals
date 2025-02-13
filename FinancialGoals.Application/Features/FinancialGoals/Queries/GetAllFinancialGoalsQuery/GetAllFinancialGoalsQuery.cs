using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetAllFinancialGoalsQuery;

public class GetAllFinancialGoalsQuery : IRequest<BaseResponse<IEnumerable<FinancialGoalDto>>>
{

}
