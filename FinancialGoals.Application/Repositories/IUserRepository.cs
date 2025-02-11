using FinancialGoals.Core.Entities;

namespace FinancialGoals.Application.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> ValidateUserAsync(string email, string password);
}
