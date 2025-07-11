using BiogenomTest.Application.BiogenomTest.Queries.GetDailyIntake;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTest.Api.Controllers.V1;

public class IndividualReportController(IMediator mediator) : ControllerBase
{
    [HttpGet("daily-intake")]
    public async Task<IActionResult> GetUserIntakes([FromQuery] GetDailyIntakesQuery request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }
}