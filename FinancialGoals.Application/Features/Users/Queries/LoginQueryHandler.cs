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
        private readonly ISecurityService _securityService;
        private readonly IUserRepository _userRepository;
        private readonly IMessageService _messageService;

        public LoginQueryHandler(IUserRepository userRepository, ITokenService tokenService, IMessageService messageService, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _messageService = messageService;
            _securityService = securityService;
        }

        public async Task<BaseResponse<UserViewModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UserViewModel>();

            try
            {
                string encryptedPassword = _securityService.EncryptPassword(request.Password);
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
                    _messageService.SendEmailAsync(user.Email, "Login", "You have successfully logged in!");
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
