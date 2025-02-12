using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.Repositories;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Commands.DeleteFinancialGoalCommand;

public class DeleteFinancialGoalCommandHandler : IRequestHandler<DeleteFinancialGoalCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFinancialGoalRepository _financialGoalRepository;

    public DeleteFinancialGoalCommandHandler(IUnitOfWork unitOfWork, IFinancialGoalRepository financialGoalRepository)
    {
        _unitOfWork = unitOfWork;
        _financialGoalRepository = financialGoalRepository;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteFinancialGoalCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {

            var financialGoal = await _financialGoalRepository.Get(command.Id, cancellationToken);
            response.Data = await _financialGoalRepository.Delete(financialGoal);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Financial Goal deleted successfuly.";
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
