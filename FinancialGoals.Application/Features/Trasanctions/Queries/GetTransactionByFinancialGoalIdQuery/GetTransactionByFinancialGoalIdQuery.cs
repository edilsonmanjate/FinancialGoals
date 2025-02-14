using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;
using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Queries.GetTransactionByFinancialGoalIdQuery;

public class GetTransactionByFinancialGoalIdQuery : IRequest<BaseResponse<IEnumerable<TransactionDto>>>
{
    public Guid FinancialGoalId { get; set; }

}
