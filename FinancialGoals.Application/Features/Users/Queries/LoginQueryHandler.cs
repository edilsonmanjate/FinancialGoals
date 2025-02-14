using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.DTOs;
using FinancialGoals.Application.Repositories;
using FinancialGoals.Application.Services;

using MediatR;

namespace FinancialGoals.Application.Features.Users.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, BaseResponse<UserViewModel>>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<BaseResponse<UserViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UserViewModel>();

            try
            {
                var user = await _userRepository.ValidateUserAsync(request.Email, request.Password);

                if (user is not null)
                {
                    
                    var token = _tokenService.GenerateToken(user);

                    var userVM = new UserViewModel
                    {
                        Email = user.Email,
                        Token = token.ToString()
                    };

                    response.Data = userVM;
                    response.Success = true;
                    response.Message = "Authentication succeed!";
                }
            }
            catch (BadRequestException ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
