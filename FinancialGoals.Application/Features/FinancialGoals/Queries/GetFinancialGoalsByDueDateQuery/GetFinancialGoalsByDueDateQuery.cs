using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByDueDateQuery;

public class GetFinancialGoalsByDueDateQuery : IRequest<BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    public DateOnly DueDate { get; set; }

}
