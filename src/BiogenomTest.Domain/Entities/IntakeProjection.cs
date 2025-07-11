namespace BiogenomTest.Domain.Entities;

//нов. потреб. с уч. набора
public class IntakeProjection
{
    public int Id { get; set; }
    
    public int DailyIntakeId { get; set; }
    public DailyIntake DailyIntake { get; set; } = null!;
    
    
    public double FromSet { get; set; }
    public double FromFood { get; set; }
}