using BiogenomTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<DailyIntake> DailyIntakes => Set<DailyIntake>();
    public DbSet<IntakeProjection> IntakeProjections => Set<IntakeProjection>();
    public DbSet<SupplementBenefit> SupplementBenefits => Set<SupplementBenefit>();
    public DbSet<SupplementProduct> SupplementProducts => Set<SupplementProduct>();
    public DbSet<Nutrient> Nutrients => Set<Nutrient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}