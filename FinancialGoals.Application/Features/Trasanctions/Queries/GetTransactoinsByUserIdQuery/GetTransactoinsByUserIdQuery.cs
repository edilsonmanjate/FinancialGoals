using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Queries.GetTransactoinsByUserIdQuery;

public class GetTransactoinsByUserIdQuery : IRequest<BaseResponse<IEnumerable<TransactionDto>>>
{
    public Guid UserId { get; set; }

}