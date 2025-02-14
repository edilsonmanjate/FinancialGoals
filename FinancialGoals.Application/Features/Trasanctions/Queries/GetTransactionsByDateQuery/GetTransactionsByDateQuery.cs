using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Queries.GetTransactionsByDateQuery;

public class GetTransactionsByDateQuery : IRequest<BaseResponse<IEnumerable<TransactionDto>>>
{
    public DateOnly Date { get; set; }

}
