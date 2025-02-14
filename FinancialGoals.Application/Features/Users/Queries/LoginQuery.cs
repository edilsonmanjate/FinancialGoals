using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.DTOs;

using MediatR;

namespace FinancialGoals.Application.Features.Users.Queries;

public class LoginQuery : IRequest<BaseResponse<UserViewModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
