namespace BiogenomTest.Domain.Entities;

//преимущ. приема БАДов
public class SupplementBenefit
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string? Category { get; set; }
}