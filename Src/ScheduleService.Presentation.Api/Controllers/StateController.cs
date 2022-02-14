using Microsoft.AspNetCore.Mvc;
using ScheduleService.Domain.CommandHandler.Commands.States;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.Core.Policies;
using ScheduleService.Domain.QueryHandler.Handlers.States;
using ScheduleService.Domain.QueryHandler.Queries.States;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : MainController
{
    [PolicyAuthorization(StatePolicy.CREATE), HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] IStateCreateHandler handler,
        [FromBody] StateCreateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [PolicyAuthorization(StatePolicy.UPDATE), HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] IStateUpdateHandler handler,
        [FromBody] StateUpdateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [PolicyAuthorization(StatePolicy.DELETE), HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] IStateDeleteHandler handler,
        [FromBody] StateDeleteCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [PolicyAuthorization(StatePolicy.VIEW), HttpGet, Route("GetViewModel")]
    public async Task<IActionResult> GetViewModel(
        [FromServices] IGetStateViewModelQueryHandler handler,
        [FromQuery] GetStateViewModel command)
    {
        var response = await handler.HandleAsync(command);
        return OkOrNotFoundQuery(response);
    }
}
