using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetSupplementProducts;

public class GetSupplementProductsQueryHandler(ApplicationDbContext context)
    : IRequestHandler<GetSupplementProductsQuery, List<SupplementProductDto>>
{
    public async Task<List<SupplementProductDto>> Handle(GetSupplementProductsQuery request,
        CancellationToken cancellationToken)
    {
        return await context.SupplementProducts
            .AsNoTracking()
            .Select(p => new SupplementProductDto(
                p.Id,
                p.Name,
                p.Description,
                p.ImageUrl,
                p.TargetedNutrient.Name))
            .ToListAsync(cancellationToken);
    }
}