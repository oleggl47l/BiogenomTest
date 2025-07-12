using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Application.BiogenomTest.Queries.GetDailyIntake;
using BiogenomTest.Application.BiogenomTest.Queries.GetIntakeProjection;
using BiogenomTest.Application.BiogenomTest.Queries.GetSupplementBenefits;
using BiogenomTest.Application.BiogenomTest.Queries.GetSupplementProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTest.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class IndividualReportController(IMediator mediator) : ControllerBase
{
    [HttpGet("daily-intake")]
    public async Task<ActionResult<List<DailyIntakeDto>>> GetUserIntakes([FromQuery] GetDailyIntakesQuery request) =>
        Ok(await mediator.Send(request));

    [HttpGet("intake-projection")]
    public async Task<ActionResult<List<IntakeProjectionDto>>> GetIntakeProjection() =>
        Ok(await mediator.Send(new GetIntakeProjectionQuery()));

    [HttpGet("supplement-benefits")]
    public async Task<ActionResult<List<SupplementBenefitDto>>> GetSupplementBenefits() =>
        Ok(await mediator.Send(new GetSupplementBenefitsQuery()));

    [HttpGet("supplement-products")]
    public async Task<ActionResult<List<SupplementProductDto>>> GetSupplementProducts() =>
        Ok(await mediator.Send(new GetSupplementProductsQuery()));
}