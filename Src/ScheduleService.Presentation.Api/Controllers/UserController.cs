using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Domain.Command.Commands.Users;
using ScheduleService.Domain.Handler.Handlers.Users;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [AllowAnonymous, HttpPost, Route("SignIn")]
    public async Task<IActionResult> SignIn(
        [FromServices] IUserSignInHandler handler,
        [FromBody] UserSignInCommand command)
    {
        var response = await handler.Handle(command, default);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
