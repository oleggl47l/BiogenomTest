using BiogenomTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Data.Configurations;

public class IntakeProjectionConfiguration : IEntityTypeConfiguration<IntakeProjection>
{
    public void Configure(EntityTypeBuilder<IntakeProjection> builder)
    {
        builder.HasData(
            new IntakeProjection { Id = 1, DailyIntakeId = 1, FromSet = 50.0, FromFood = 0.0 },
            new IntakeProjection { Id = 2, DailyIntakeId = 2, FromSet = 330.0, FromFood = 40.0 }
        );
    }
}