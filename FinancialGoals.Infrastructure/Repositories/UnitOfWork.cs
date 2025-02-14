using FinancialGoals.Application.Repositories;
using FinancialGoals.Infrastructure.Persistence;

namespace FinancialGoals.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly FinancialGoalsDbContext _context;

    public UnitOfWork(FinancialGoalsDbContext context)
    {
        _context = context;
    }

    public Task Save(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
