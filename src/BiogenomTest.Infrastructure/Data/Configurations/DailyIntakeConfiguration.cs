using BiogenomTest.Domain.Entities;
using BiogenomTest.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Data.Configurations;

public class DailyIntakeConfiguration : IEntityTypeConfiguration<DailyIntake>
{
    public void Configure(EntityTypeBuilder<DailyIntake> builder)
    {
        builder.HasOne(di => di.Nutrient)
            .WithMany(n => n.DailyIntakes)
            .HasForeignKey(di => di.NutrientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(di => di.Projection)
            .WithOne(ip => ip.DailyIntake)
            .HasForeignKey<IntakeProjection>(ip => ip.DailyIntakeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new DailyIntake { Id = 1, NutrientId = 1, Amount = 7.04, Status = IntakeStatus.Low },
            new DailyIntake { Id = 2, NutrientId = 2, Amount = 42.39, Status = IntakeStatus.Low },
            new DailyIntake { Id = 3, NutrientId = 3, Amount = 1547.07, Status = IntakeStatus.Low },
            new DailyIntake { Id = 4, NutrientId = 4, Amount = 225.6, Status = IntakeStatus.Normal }
        );
    }
}