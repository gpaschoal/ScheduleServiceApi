using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Handler.Handlers.Countries;
using ScheduleService.Domain.Command.Commands.Countries;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    [Authorize, HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] ICountryCreateHandler handler,
        [FromBody] CountryCreateCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] ICountryUpdateHandler handler,
        [FromBody] CountryUpdateCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] ICountryDeleteHandler handler,
        [FromBody] CountryDeleteCommand command)
    {
        var response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
