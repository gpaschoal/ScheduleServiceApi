using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Command.Queries.States;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.QueryHandler.Handlers.States;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : MainController
{
    [Authorize, HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] IStateCreateHandler handler,
        [FromBody] StateCreateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [Authorize, HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] IStateUpdateHandler handler,
        [FromBody] StateUpdateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [Authorize, HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] IStateDeleteHandler handler,
        [FromBody] StateDeleteCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [Authorize, HttpGet, Route("GetViewModel")]
    public async Task<IActionResult> GetViewModel(
        [FromServices] IGetStateViewModelQueryHandler handler,
        [FromQuery] GetStateViewModel command)
    {
        var response = await handler.HandleAsync(command);

        return OkOrNotFoundQuery(response);
    }
}
