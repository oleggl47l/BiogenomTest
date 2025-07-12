namespace BiogenomTest.Domain.Entities;

//персонализированный набор
public class SupplementProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }

    public int TargetedNutrientId { get; set; }
    public Nutrient TargetedNutrient { get; set; } = null!;
}