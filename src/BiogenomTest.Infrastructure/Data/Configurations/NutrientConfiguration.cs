using BiogenomTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Data.Configurations;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
    public void Configure(EntityTypeBuilder<Nutrient> builder)
    {
        builder.HasData(
            new Nutrient { Id = 1, Name = "Vitamin D", Unit = "mcg", Norm = 15.0 },
            new Nutrient { Id = 2, Name = "Vitamin C (ascorbic acid)", Unit = "mg", Norm = 100 },
            new Nutrient { Id = 3, Name = "Water", Unit = "g", NormMin = 1800, NormMax = 1900 },
            new Nutrient { Id = 4, Name = "Protein", Unit = "g", Norm = 102.0 }
        );
    }
}