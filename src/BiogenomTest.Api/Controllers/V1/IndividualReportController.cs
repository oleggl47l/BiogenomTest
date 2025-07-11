using BiogenomTest.Application.BiogenomTest.DTOs;
using BiogenomTest.Application.BiogenomTest.Queries.GetDailyIntake;
using BiogenomTest.Application.BiogenomTest.Queries.GetIntakeProjection;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTest.Api.Controllers.V1;

public class IndividualReportController(IMediator mediator) : ControllerBase
{
    [HttpGet("daily-intake")]
    public async Task<ActionResult<List<DailyIntakeDto>>> GetUserIntakes([FromQuery] GetDailyIntakesQuery request) =>
            Ok(await mediator.Send(request));
    
    [HttpGet("intake-projection")]
    public async Task<ActionResult<List<IntakeProjectionDto>>> GetIntakeProjection() =>
        Ok(await mediator.Send(new GetIntakeProjectionQuery()));
}