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
        
        builder.HasData(
            new SupplementProduct 
            { 
                Id = 1, 
                Name = "Vitamin D3 Complex", 
                Description = "Advanced formula with vitamin D3 and K2", 
                ImageUrl = "images/vitamin-d.jpg", 
                TargetedNutrientId = 1 
            },
            new SupplementProduct 
            { 
                Id = 2, 
                Name = "Premium Vitamin C", 
                Description = "Sustained-release vitamin C with bioflavonoids", 
                ImageUrl = "images/vitamin-c.jpg", 
                TargetedNutrientId = 2 
            },
            new SupplementProduct 
            { 
                Id = 3, 
                Name = "Protein Matrix", 
                Description = "Complete plant-based protein blend", 
                ImageUrl = "images/protein.jpg", 
                TargetedNutrientId = 4 
            }
        );
    }
}