using FinancialGoals.Application.Repositories;
using FinancialGoals.Core.Entities;
using FinancialGoals.Core.Enums;
using FinancialGoals.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace FinancialGoals.Infrastructure.Repositories;

public class TransactionRepository : BaseRepository<Trasanction>, ITrasanctionRepository
{
    public TransactionRepository(FinancialGoalsDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Trasanction>> GetByFinancialGoalId(Guid financialGoalId, CancellationToken cancellationToken)
    {
        return await _context.Trasanctions.Where(t => t.FinancialGoalId == financialGoalId).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Trasanction>> GetByDate(DateOnly date, CancellationToken cancellationToken)
    {
        return await _context.Trasanctions.Where(t => t.Date == date).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Trasanction>> GetByTransactionType(TransactionType transactionType, CancellationToken cancellationToken)
    {
        return await _context.Trasanctions.Where(t => t.TransactionType == transactionType).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Trasanction>> GetByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Trasanctions.Where(t => t.UserId == userId).ToListAsync(cancellationToken);
    }
}
