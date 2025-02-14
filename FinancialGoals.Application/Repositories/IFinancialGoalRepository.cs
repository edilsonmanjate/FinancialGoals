using FinancialGoals.Core.Entities;
using FinancialGoals.Core.Enums;

namespace FinancialGoals.Application.Repositories;

public interface IFinancialGoalRepository : IBaseRepository<FinancialGoal>
{
    Task<IEnumerable<FinancialGoal>> getByDueDate(DateOnly dueDate, CancellationToken cancellationToken);
    Task<IEnumerable<FinancialGoal>> getByStatus(Status status, CancellationToken cancellationToken);
    Task<IEnumerable<FinancialGoal>> getByTarget(decimal target, CancellationToken cancellationToken);
    Task<IEnumerable<FinancialGoal>> getByUserId(Guid userId, CancellationToken cancellationToken);
    Task<IEnumerable<FinancialGoal>> getByIdealMonthlyAmount(decimal idealMonthlyAmount, CancellationToken cancellationToken);
}
