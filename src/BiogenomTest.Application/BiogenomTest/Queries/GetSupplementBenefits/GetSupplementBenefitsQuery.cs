using BiogenomTest.Application.BiogenomTest.DTOs;
using MediatR;

namespace BiogenomTest.Application.BiogenomTest.Queries.GetSupplementBenefits;

public record GetSupplementBenefitsQuery : IRequest<List<SupplementBenefitDto>>;