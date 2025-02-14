using FinancialGoals.Application.Repositories;
using FinancialGoals.Core.Entities;
using FinancialGoals.Core.Enums;
using FinancialGoals.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace FinancialGoals.Infrastructure.Repositories;

public class FinancialGoalRepository : BaseRepository<FinancialGoal>, IFinancialGoalRepository
{

    public FinancialGoalRepository(FinancialGoalsDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FinancialGoal>> getByDueDate(DateOnly dueDate, CancellationToken cancellationToken)
    {
        return await _context.FinancialGoals.Where(x => x.DueDate == dueDate).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<FinancialGoal>> getByIdealMonthlyAmount(decimal idealMonthlyAmount, CancellationToken cancellationToken)
    {
        return await _context.FinancialGoals.Where(x => x.IdealMonthlyAmount == idealMonthlyAmount).ToListAsync(cancellationToken);

    }

    public async Task<IEnumerable<FinancialGoal>> getByStatus(Status status, CancellationToken cancellationToken)
    {
        return await _context.FinancialGoals.Where(x => x.Status == status).ToListAsync(cancellationToken);

    }

    public async Task<IEnumerable<FinancialGoal>> getByTarget(decimal target, CancellationToken cancellationToken)
    {
        return await _context.FinancialGoals.Where(x => x.Target == target).ToListAsync(cancellationToken);

    }

    public  async Task<IEnumerable<FinancialGoal>> getByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.FinancialGoals.Where(x => x.UserId == userId).ToListAsync(cancellationToken);

    }
}
