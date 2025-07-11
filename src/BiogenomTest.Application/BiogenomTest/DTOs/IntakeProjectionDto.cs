namespace BiogenomTest.Application.BiogenomTest.DTOs;

public record IntakeProjectionDto(
    int Id,
    string NutrientName,
    double Amount,
    string Unit,
    double FromFood,
    double FromSet
);