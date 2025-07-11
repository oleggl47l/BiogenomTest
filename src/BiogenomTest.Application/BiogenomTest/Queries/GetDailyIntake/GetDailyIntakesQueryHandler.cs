using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetDailyIntake;

public class GetDailyIntakesQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetDailyIntakesQuery, List<DailyIntakeDto>>
{
    public async Task<List<DailyIntakeDto>> Handle(GetDailyIntakesQuery request, CancellationToken cancellationToken)
    {
        var result = await context.DailyIntakes
            .AsNoTracking()
            .Where(x => request.Status == null || x.Status == request.Status)
            .Select(x => new DailyIntakeDto(
                x.Id,
                x.NutrientName,
                x.Amount,
                x.Unit,
                x.Norm,
                x.NormMin,
                x.NormMax,
                x.Status
            ))
            .ToListAsync(cancellationToken);
        
        return result;
    }
}