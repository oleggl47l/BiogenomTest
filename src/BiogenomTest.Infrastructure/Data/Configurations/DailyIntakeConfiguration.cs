using BiogenomTest.Domain.Entities;
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
    }
}