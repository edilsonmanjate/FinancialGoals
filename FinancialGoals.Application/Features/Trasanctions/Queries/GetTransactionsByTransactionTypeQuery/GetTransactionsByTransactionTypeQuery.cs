using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Core.Enums;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Queries.GetTransactionsByTransactionTypeQuery;

public class GetTransactionsByTransactionTypeQuery : IRequest<BaseResponse<IEnumerable<TransactionDto>>>
{
    public TransactionType TransactionType { get; set; }

}
