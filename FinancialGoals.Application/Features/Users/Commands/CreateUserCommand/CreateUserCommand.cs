using FinancialGoals.Application.Common.Bases;

using MediatR;

namespace FinancialGoals.Application.Features.Users.Commands.CreateUserCommand;

public class CreateUserCommand : IRequest<BaseResponse<bool>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string ConfirmPassword { get; private set; }
}
