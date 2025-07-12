using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetSupplementBenefits;

public class GetSupplementBenefitsQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetSupplementBenefitsQuery, List<SupplementBenefitDto>>
{
    public async Task<List<SupplementBenefitDto>> Handle(GetSupplementBenefitsQuery request,
        CancellationToken cancellationToken)
    {
        return await context.SupplementBenefits
            .AsNoTracking()
            .Select(b => new SupplementBenefitDto(b.Id, b.Title))
            .ToListAsync(cancellationToken);
    }
}