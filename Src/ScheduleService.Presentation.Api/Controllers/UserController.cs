using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Response.Responses.Users;
using ScheduleService.Application.Shared;
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
        CustomResultData<UserSignInResponse> response = await handler.Handle(command);

        if (response.IsValid)
            return Ok(response);
        return BadRequest(response);
    }
}
