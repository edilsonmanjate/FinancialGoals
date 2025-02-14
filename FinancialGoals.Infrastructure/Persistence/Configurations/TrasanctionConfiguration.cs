using FinancialGoals.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialGoals.Infrastructure.Persistence.Configurations;

public class TrasanctionConfiguration : IEntityTypeConfiguration<Trasanction>
{
    public void Configure(EntityTypeBuilder<Trasanction> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(t => t.Quantity)
            .HasPrecision(18,2)
            .IsRequired();

        builder.Property(t => t.TransactionType)
            .IsRequired();

        builder.Property(t => t.Date)
            .IsRequired();

        builder.Property(t => t.FinancialGoalId)
            .IsRequired();

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.ActualTotal)
            .HasPrecision(18,2)
            .IsRequired();
    }
}
