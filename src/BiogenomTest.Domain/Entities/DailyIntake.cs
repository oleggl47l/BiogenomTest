using BiogenomTest.Domain.Enums;

namespace BiogenomTest.Domain.Entities;

//тек. суточное потреб.
public class DailyIntake
{
    public int Id { get; set; }

    public string NutrientName { get; set; } = null!;
    public double Amount { get; set; }
    public string Unit { get; set; } = null!;

    public double? Norm { get; set; }
    public double? NormMin { get; set; }
    public double? NormMax { get; set; }

    public IntakeStatus Status { get; set; }
    
    public IntakeProjection? Projection { get; set; } 
}