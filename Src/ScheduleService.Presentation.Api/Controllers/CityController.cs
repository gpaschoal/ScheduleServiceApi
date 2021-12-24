﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Command.Commands.Cities;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize, HttpPost, Route("Create")]
    public async Task<IActionResult> Create(
       [FromBody] CityCreateCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPost, Route("Update")]
    public async Task<IActionResult> Update(
        [FromBody] CityUpdateCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }

    [Authorize, HttpPost, Route("Delete")]
    public async Task<IActionResult> Delete(
        [FromBody] CityDeleteCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
