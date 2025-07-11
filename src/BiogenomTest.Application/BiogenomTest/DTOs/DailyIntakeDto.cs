using BiogenomTest.Domain.Enums;

namespace BiogenomTest.Application.BiogenomTest.DTOs;

public record DailyIntakeDto(
    int Id,
    string NutrientName,
    double Amount,
    string Unit,
    double? Norm,
    double? NormMin,
    double? NormMax,
    IntakeStatus Status
);