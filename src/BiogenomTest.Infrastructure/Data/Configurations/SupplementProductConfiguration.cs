using BiogenomTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Data.Configurations;

public class SupplementProductConfiguration : IEntityTypeConfiguration<SupplementProduct>
{
    public void Configure(EntityTypeBuilder<SupplementProduct> builder)
    {
        builder.HasOne(sp => sp.TargetedNutrient)
            .WithMany(n => n.SupplementProducts)
            .HasForeignKey(sp => sp.TargetedNutrientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}