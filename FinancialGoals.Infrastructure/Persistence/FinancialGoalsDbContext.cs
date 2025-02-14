using FinancialGoals.Core.Entities;
using FinancialGoals.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;

namespace FinancialGoals.Infrastructure.Persistence;

public class FinancialGoalsDbContext : DbContext
{
    public FinancialGoalsDbContext(DbContextOptions<FinancialGoalsDbContext> opt) : base(opt)
    {}

    public DbSet<FinancialGoal> FinancialGoals { get; set; }
    public DbSet<Trasanction> Trasanctions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FinancialGoalConfiguration());
        modelBuilder.ApplyConfiguration(new TrasanctionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

}
