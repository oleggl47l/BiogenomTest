using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Domain.Enums;
using MediatR;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetDailyIntake;

public record GetDailyIntakesQuery(IntakeStatus? Status) : IRequest<List<DailyIntakeDto>>;