using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.CommandHandler.Handlers.Countries;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : MainController
{
    [Authorize, HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] ICountryCreateHandler handler,
        [FromBody] CountryCreateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [Authorize, HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] ICountryUpdateHandler handler,
        [FromBody] CountryUpdateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [Authorize, HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] ICountryDeleteHandler handler,
        [FromBody] CountryDeleteCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }
}
