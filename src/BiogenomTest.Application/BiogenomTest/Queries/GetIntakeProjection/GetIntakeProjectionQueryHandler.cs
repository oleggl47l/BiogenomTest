using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Domain.Enums;
using BiogenomTest.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetIntakeProjection;

public class GetIntakeProjectionQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetIntakeProjectionQuery, List<IntakeProjectionDto>>
{
    public async Task<List<IntakeProjectionDto>> Handle(GetIntakeProjectionQuery request,
        CancellationToken cancellationToken)
    {
        return await context.DailyIntakes
            .AsNoTracking()
            .Include(di => di.Projection)
            .Where(di => di.Status == IntakeStatus.Low && di.Projection != null)
            .Select(di => new IntakeProjectionDto(
                di.Projection!.Id,
                di.NutrientName,
                di.Amount,
                di.Unit,
                di.Projection.FromFood,
                di.Projection.FromSet
            ))
            .ToListAsync(cancellationToken);
    }
}