using FinancialGoals.Application.Common.Bases;

using MediatR;

namespace FinancialGoals.Application.Features.Trasanctions.Commands.DeleteTrasanctionCommand;

public class DeleteTrasanctionCommand : IRequest<BaseResponse<bool>>
{
    public Guid Id { get; set; }
}
