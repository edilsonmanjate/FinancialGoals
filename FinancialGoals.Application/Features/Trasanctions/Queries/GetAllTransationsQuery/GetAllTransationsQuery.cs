using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Queries.GetAllTransationsQuery;

public class GetAllTransationsQuery : IRequest<BaseResponse<IEnumerable<TransactionDto>>>
{

}

