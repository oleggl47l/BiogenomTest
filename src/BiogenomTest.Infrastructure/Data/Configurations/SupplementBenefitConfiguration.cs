using BiogenomTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.Infrastructure.Data.Configurations;

public class SupplementBenefitConfiguration : IEntityTypeConfiguration<SupplementBenefit>
{
    public void Configure(EntityTypeBuilder<SupplementBenefit> builder)
    {
        builder.HasData(
            new SupplementBenefit { Id = 1, Title = "Eliminate vitamin and mineral deficiency" },
            new SupplementBenefit { Id = 2, Title = "Improve the absorption of nutrients from food" },
            new SupplementBenefit { Id = 3, Title = "Compensate for an unbalanced diet" },
            new SupplementBenefit { Id = 4, Title = "Provide the body with vital elements" },
            new SupplementBenefit { Id = 5, Title = "Increase the functional reserves of the body" }
        );
    }
}