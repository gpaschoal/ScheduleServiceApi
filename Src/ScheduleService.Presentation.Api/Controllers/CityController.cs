using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Handlers.Cities;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : MainController
{
    [Authorize, HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] ICityCreateHandler handler,
        [FromBody] CityCreateCommand command)
    {
        var response = await handler.Handle(command);

        return CustomResponse(response);
    }

    [Authorize, HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] ICityUpdateHandler handler,
        [FromBody] CityUpdateCommand command)
    {
        var response = await handler.Handle(command);

        return CustomResponse(response);
    }

    [Authorize, HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] ICityDeleteHandler handler,
        [FromBody] CityDeleteCommand command)
    {
        var response = await handler.Handle(command);

        return CustomResponse(response);
    }
}
