using BiogenomTest.Application.BiogenomTest.DTOs;
using MediatR;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetSupplementProducts;

public record GetSupplementProductsQuery : IRequest<List<SupplementProductDto>>;