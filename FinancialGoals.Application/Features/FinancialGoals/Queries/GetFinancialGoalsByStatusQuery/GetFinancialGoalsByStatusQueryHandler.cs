using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Application.Repositories;
using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Queries.GetFinancialGoalsByStatusQuery;

public class GetFinancialGoalsByStatusQueryHandler : IRequestHandler<GetFinancialGoalsByStatusQuery, BaseResponse<IEnumerable<FinancialGoalDto>>>
{
    private readonly IFinancialGoalRepository _financialGoalRepository;

    public GetFinancialGoalsByStatusQueryHandler(IFinancialGoalRepository financialGoalRepository)
    {
        _financialGoalRepository = financialGoalRepository;
    }

    public async Task<BaseResponse<IEnumerable<FinancialGoalDto>>> Handle(GetFinancialGoalsByStatusQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<FinancialGoalDto>>();
        try
        {
            var financialGoals = await _financialGoalRepository.getByStatus(request.Status, cancellationToken);
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
