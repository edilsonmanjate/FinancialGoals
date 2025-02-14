using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Application.Repositories;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoals.Application.Features.Trasanctions.Queries.GetTransactoinsByUserIdQuery;

public class GetTransactoinsByUserIdQueryHandler : IRequestHandler<GetTransactoinsByUserIdQuery, BaseResponse<IEnumerable<TransactionDto>>>
{
    private readonly ITrasanctionRepository _trasanctionRepository;

    public GetTransactoinsByUserIdQueryHandler(ITrasanctionRepository trasanctionRepository)
    {
        _trasanctionRepository = trasanctionRepository;
    }

    public async Task<BaseResponse<IEnumerable<TransactionDto>>> Handle(GetTransactoinsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<TransactionDto>>();
        try
        {
            var transactions = await _trasanctionRepository.GetByUserId(request.UserId, cancellationToken);
            var transactionsDtos = new List<TransactionDto>();

            foreach (var transactionDto in transactionsDtos)
            {
                var tDto = new TransactionDto
                {
                    Id = transactionDto.Id,
                    Title = transactionDto.Title,
                    Target = transactionDto.Target,
                    DueDate = transactionDto.DueDate,
                    IdealMonthlyAmount = transactionDto.IdealMonthlyAmount,
                    Status = transactionDto.Status,
                    UserId = transactionDto.UserId

                };
                transactionsDtos.Add(tDto);
            }

            if (transactions is not null)
            {
                response.Data = transactionsDtos;
                response.Success = true;
                response.Message = "Query succeed!";
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
