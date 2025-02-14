using FinancialGoals.Application.Common.Bases;
using FinancialGoals.Application.Common.Exceptions;
using FinancialGoals.Application.Repositories;
using FinancialGoals.Application.Services;
using FinancialGoals.Core.Entities;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoals.Application.Features.Users.Commands.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISecurityService _securityService;
    private readonly IMessageService _messageService;


    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ISecurityService securityService, IMessageService messageService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _securityService = securityService;
        _messageService = messageService;
    }

    public async Task<BaseResponse<bool>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {

            string encryptedPassword = _securityService.EncryptPassword(command.Password);

            var user = new User(command.FirstName,command.LastName,command.Email, encryptedPassword);

            response.Data = await _userRepository.Create(user);
            await _unitOfWork.Save(cancellationToken);

            if (response.Data)
            {
                response.Success = true;
                response.Message = "Transaction created successfully";

                //transoformar em evento 
                _messageService.SendEmailAsync(user.Email, "Welcome to Financial Goals", "Welcome to Financial Goals");
            }
        }
        catch (BadRequestException ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
