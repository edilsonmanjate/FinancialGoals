using FinancialGoals.Core.Enums;

namespace FinancialGoals.Core.Entities;

public class Trasanction : BaseEntity
{
    public Trasanction(decimal quantity, TransactionType transactionType, DateOnly date, Guid financialGoalId, Guid userId)
    {
        Quantity = quantity;
        TransactionType = transactionType;
        Date = date;
        FinancialGoalId = financialGoalId;
        UserId = userId;
    }

    public decimal Quantity { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public DateOnly Date { get; private set; }
    public Guid FinancialGoalId { get; private set; }
    public Guid UserId { get; set; }
}
