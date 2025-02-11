namespace FinancialGoals.Application.Repositories;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}