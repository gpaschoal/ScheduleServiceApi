using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Command.Commands.Countries;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize, HttpPost, Route("Create")]
    public async Task<IActionResult> Create(
       [FromBody] CountryCreateCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPost, Route("Update")]
    public async Task<IActionResult> Update(
        [FromBody] CountryUpdateCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPost, Route("Delete")]
    public async Task<IActionResult> Delete(
        [FromBody] CountryDeleteCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
