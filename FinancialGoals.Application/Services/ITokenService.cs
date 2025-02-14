using FinancialGoals.Core.Entities;

namespace FinancialGoals.Application.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}