using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.CommandResponses.Users;
using ScheduleService.Domain.CommandHandler.Commands.Users;
using ScheduleService.Domain.CommandHandler.Handlers.Users;
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
        CustomResultData<UserSignInResponse> response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }
}
