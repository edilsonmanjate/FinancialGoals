using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.Repositories;
using FinancialGoals.Core.Entities;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.CreateTrasanctionCommand;

public class CreateTrasanctionCommandHandler : IRequestHandler<CreateTrasanctionCommand, BaseResponse<bool>>
{
    private readonly ITrasanctionRepository _trasanctionRepository;
    private readonly IUnitOfWork _unitOfWork;


    public CreateTrasanctionCommandHandler(ITrasanctionRepository trasanctionRepository, IUnitOfWork unitOfWork)
    {
        _trasanctionRepository = trasanctionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(CreateTrasanctionCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {

            var trasanction = new Trasanction(
                command.Quantity,
                command.TransactionType,
                command.Date,
                command.FinancialGoalId,
                command.UserId,
                command.ActualTotal);

            response.Data = await _trasanctionRepository.Create(trasanction);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Transaction created successfully";
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
