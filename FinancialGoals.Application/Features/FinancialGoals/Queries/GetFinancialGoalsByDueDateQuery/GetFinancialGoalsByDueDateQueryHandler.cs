using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Application.Repositories;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByDueDateQuery;

public class GetFinancialGoalsByDueDateQueryHandler : IRequestHandler<GetFinancialGoalsByDueDateQuery, BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    private readonly IFinancialGoalRepository _financialGoalRepository;

    public GetFinancialGoalsByDueDateQueryHandler(IFinancialGoalRepository financialGoalRepository)
    {
        _financialGoalRepository = financialGoalRepository;
    }

    public async Task<BaseResponse<IEnumerable<FinancialGoalDto>>> Handle(GetFinancialGoalsByDueDateQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<FinancialGoalDto>>();
        try
        {
            var financialGoals = await _financialGoalRepository.getByDueDate(request.DueDate, cancellationToken);
            var financialGoalsDtos = new List<FinancialGoalDto>();

            foreach (var financialGoal in financialGoals)
            {
                var finGoal = new FinancialGoalDto
                {
                    Id = financialGoal.Id,
                    Title = financialGoal.Title,
                    Target = financialGoal.Target,
                    DueDate = financialGoal.DueDate,
                    IdealMonthlyAmount = financialGoal.IdealMonthlyAmount,
                    Status = financialGoal.Status,
                    UserId = financialGoal.UserId,
                    Trasanctions = financialGoal.Trasanctions
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
