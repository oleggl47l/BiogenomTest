namespace BiogenomTest.Application.BiogenomTest.DTOs;

public record SupplementProductDto(
    int Id,
    string Name,
    string Description,
    string? ImageUrl,
    string NutrientTargeted
);