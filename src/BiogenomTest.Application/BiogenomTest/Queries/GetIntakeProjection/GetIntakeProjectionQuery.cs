using BiogenomTest.Application.BiogenomTest.DTOs;
using MediatR;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetIntakeProjection;

public record GetIntakeProjectionQuery : IRequest<List<IntakeProjectionDto>>;