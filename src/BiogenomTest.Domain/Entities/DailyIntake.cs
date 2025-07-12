using BiogenomTest.Domain.Enums;

namespace BiogenomTest.Domain.Entities;

//тек. суточное потреб.
public class DailyIntake
{
    public int Id { get; set; }

    public int NutrientId { get; set; }
    public Nutrient Nutrient { get; set; } = null!;

    public double Amount { get; set; }
    public IntakeStatus Status { get; set; }

    public IntakeProjection? Projection { get; set; }
}