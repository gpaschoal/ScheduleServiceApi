using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Command.Commands.Users;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous, HttpPost, Route("SignIn")]
    public async Task<IActionResult> SignIn(
       [FromBody] UserSignInCommand command)
    {
        var response = await _mediator.Send(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
