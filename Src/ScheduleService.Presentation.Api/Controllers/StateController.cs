using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Handler.Handlers.States;
using ScheduleService.Domain.Command.Commands.States;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    [Authorize, HttpPost, Route("")]
    public async Task<IActionResult> Create(
    [FromServices] IStateCreateHandler handler,
       [FromBody] StateCreateCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] IStateUpdateHandler handler,
        [FromBody] StateUpdateCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] IStateDeleteHandler handler,
        [FromBody] StateDeleteCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
