using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Application.Repositories;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetAllFinancialGoalsQuery;

public class GetAllFinancialGoalsQueryHandler : IRequestHandler<GetAllFinancialGoalsQuery, BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    private readonly IFinancialGoalRepository _financialGoalRepository;

    public GetAllFinancialGoalsQueryHandler(IFinancialGoalRepository financialGoalRepository)
    {
        _financialGoalRepository = financialGoalRepository;
    }

    public async Task<BaseResponse<IEnumerable<FinancialGoalDto>>> Handle(GetAllFinancialGoalsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<FinancialGoalDto>>();
        try
        {
            var financialGoals = await _financialGoalRepository.GetAll(cancellationToken);
            var financialGoalsDtos = new List<FinancialGoalDto>();

            foreach (var financialGoalDto in financialGoalsDtos)
            {
                var finGoal = new FinancialGoalDto
                {
                    Id = financialGoalDto.Id,
                    Title = financialGoalDto.Title,
                    Target = financialGoalDto.Target,
                    DueDate = financialGoalDto.DueDate,
                    IdealMonthlyAmount = financialGoalDto.IdealMonthlyAmount,
                    Status = financialGoalDto.Status,
                    UserId = financialGoalDto.UserId,
                    Trasanctions = financialGoalDto.Trasanctions
                };
                financialGoalsDtos.Add(finGoal);
            }

            if (financialGoals is not null)
            {
                response.Data = financialGoalsDtos;
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
