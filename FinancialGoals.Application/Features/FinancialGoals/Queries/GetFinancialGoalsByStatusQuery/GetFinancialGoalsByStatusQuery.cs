using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Core.Enums;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByStatusQuery;

public class GetFinancialGoalsByStatusQuery : IRequest<BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    public Status Status { get; set; }

}