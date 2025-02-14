using FinancialGoals.Core.Entities;
using FinancialGoals.Core.Enums;

namespace FinancialGoals.Application.Repositories;

public interface ITrasanctionRepository : IBaseRepository<Trasanction>
{
    Task<IEnumerable<Trasanction>> GetByFinancialGoalId(Guid financialGoalId, CancellationToken cancellationToken);
    Task<IEnumerable<Trasanction>> GetByDate(DateOnly date, CancellationToken cancellationToken);

    Task<IEnumerable<Trasanction>> GetByTransactionType(TransactionType trasanctionType, CancellationToken cancellationToken);

    Task<IEnumerable<Trasanction>> GetByUserId(Guid userId, CancellationToken cancellationToken);

}
