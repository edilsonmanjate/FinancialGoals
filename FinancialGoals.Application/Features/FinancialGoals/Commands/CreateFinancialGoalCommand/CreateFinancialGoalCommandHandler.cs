using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.Repositories;
using FinancialGoals.Application.Services;
using FinancialGoals.Core.Entities;

using MediatR;

namespace FinancialGoals.Application.Features.FinancialGoals.Commands.CreateFinancialGoalCommand;

public class CreateFinancialGoalCommandHandler : IRequestHandler<CreateFinancialGoalCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFinancialGoalRepository _financialGoalRepository;
    private readonly IAzureBloobStorageService _azureBloobStorageService;

    public CreateFinancialGoalCommandHandler(IUnitOfWork unitOfWork, IFinancialGoalRepository financialGoalRepository, IAzureBloobStorageService azureBloobStorageService)
    {
        _unitOfWork = unitOfWork;
        _financialGoalRepository = financialGoalRepository;
        _azureBloobStorageService = azureBloobStorageService;
    }

    public async Task<BaseResponse<bool>> Handle(CreateFinancialGoalCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var financialGoal = new FinancialGoal(
                command.Title,
                command.Target,
                command.DueDate,
                command.IdealMonthlyAmount,
                command.Image,
                command.Status, [],
                command.UserId);

            response.Data = await _financialGoalRepository.Create(financialGoal);
            await _unitOfWork.Save(cancellationToken);

            await _azureBloobStorageService.UploadFileAsync("financial-goals", command.Image);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Financial goal created successfully";
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
