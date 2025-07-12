namespace BiogenomTest.Domain.Entities;

public class Nutrient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public double? Norm { get; set; }
    public double? NormMin { get; set; }
    public double? NormMax { get; set; }
    
    public ICollection<DailyIntake> DailyIntakes { get; set; } = new List<DailyIntake>();
}