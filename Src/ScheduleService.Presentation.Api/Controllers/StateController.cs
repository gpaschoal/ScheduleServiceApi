using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Command.Commands.States;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IMediator _mediator;

    public StateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous, HttpPost, Route("Create")]
    public async Task<IActionResult> Create(
       [FromBody] StateCreateCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [AllowAnonymous, HttpPost, Route("Update")]
    public async Task<IActionResult> Update(
        [FromBody] StateUpdateCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [AllowAnonymous, HttpPost, Route("Delete")]
    public async Task<IActionResult> Delete(
        [FromBody] StateDeleteCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
