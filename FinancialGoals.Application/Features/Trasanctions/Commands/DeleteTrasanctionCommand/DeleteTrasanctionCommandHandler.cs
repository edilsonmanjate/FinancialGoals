using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.Repositories;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.DeleteTrasanctionCommand;

public class DeleteTrasanctionCommandHandler : IRequestHandler<DeleteTrasanctionCommand, BaseResponse<bool>>
{
    private readonly ITrasanctionRepository _trasanctionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTrasanctionCommandHandler(ITrasanctionRepository trasanctionRepository, IUnitOfWork unitOfWork)
    {
        _trasanctionRepository = trasanctionRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResponse<bool>> Handle(DeleteTrasanctionCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {

            var transaction = await _trasanctionRepository.Get(command.Id, cancellationToken);
            response.Data = await _trasanctionRepository.Delete(transaction);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Transaction deleted successfuly.";
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
