using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Response.Responses.Users;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Users;
using ScheduleService.Domain.Handler.Handlers.Users;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : MainController
{
    [AllowAnonymous, HttpPost, Route("SignIn")]
    public async Task<IActionResult> SignIn(
        [FromServices] IUserSignInHandler handler,
        [FromBody] UserSignInCommand command)
    {
        CustomResultData<UserSignInResponse> response = await handler.Handle(command);

        return CustomResponse(response);
    }
}
