using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Handler.Handlers.Cities;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    [Authorize, HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] ICityCreateHandler handler,
        [FromBody] CityCreateCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] ICityUpdateHandler handler,
        [FromBody] CityUpdateCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] ICityDeleteHandler handler,  
        [FromBody] CityDeleteCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
