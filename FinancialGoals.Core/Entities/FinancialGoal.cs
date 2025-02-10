using FinancialGoals.Core.Enums;

namespace FinancialGoals.Core.Entities;

public class FinancialGoal : BaseEntity
{
    public FinancialGoal(string title, decimal target, DateOnly dueDate, decimal idealMonthlyAmount, Status status, List<Trasanction> trasanctions, Guid userId)
    {
        Title = title;
        Target = target;
        DueDate = dueDate;
        IdealMonthlyAmount = idealMonthlyAmount;
        Status = status;
        Trasanctions = new List<Trasanction>();
        UserId = userId;
    }

    public FinancialGoal()
    {
        Trasanctions = new List<Trasanction>();
    }

    public string Title { get; private set; }
    public decimal Target { get; private set; }
    public DateOnly DueDate { get; private set; }
    public decimal IdealMonthlyAmount { get; private set; }
    public Status Status { get; private set; }
    public Guid UserId { get; set; }
    public List<Trasanction> Trasanctions { get; private set; }



}
