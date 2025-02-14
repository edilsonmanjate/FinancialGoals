using FinancialGoals.Core.Entities;
using FinancialGoals.Core.Enums;

namespace FinancialGoals.Application.DTOs;

public class FinancialGoalDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Target { get; set; }
    public DateOnly DueDate { get; set; }
    public decimal IdealMonthlyAmount { get; set; }
    public Status Status { get; set; }
    public Guid UserId { get; set; }
    public string ImageUrl { get; set; }

    public List<Trasanction> Trasanctions { get; set; }
}
