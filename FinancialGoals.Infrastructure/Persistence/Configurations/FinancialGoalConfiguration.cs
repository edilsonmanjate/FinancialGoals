using FinancialGoals.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoals.Infrastructure.Persistence.Configurations;

public class FinancialGoalConfiguration : IEntityTypeConfiguration<FinancialGoal>
{
    public void Configure(EntityTypeBuilder<FinancialGoal> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Target).HasPrecision(18,2).IsRequired();
        builder.Property(e => e.DueDate).IsRequired();
        builder.Property(e => e.IdealMonthlyAmount).HasPrecision(18,2).IsRequired();
    }
}
