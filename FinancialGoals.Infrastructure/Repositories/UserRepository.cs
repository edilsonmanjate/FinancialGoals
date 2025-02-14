using FinancialGoals.Application.Repositories;
using FinancialGoals.Core.Entities;
using FinancialGoals.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace FinancialGoals.Infrastructure.Repositories;


public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly FinancialGoalsDbContext _context;

    public UserRepository(FinancialGoalsDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> ValidateUserAsync(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }


}
