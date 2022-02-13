using Microsoft.AspNetCore.Mvc;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Command.Queries.Countries;
using ScheduleService.Domain.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.Core.Policies;
using ScheduleService.Domain.QueryHandler.Handlers.Countries;
using ScheduleService.Presentation.Api.Controllers.Base;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : MainController
{
    [PolicyAuthorization(CountryPolicy.CREATE), HttpPost, Route("")]
    public async Task<IActionResult> Create(
        [FromServices] ICountryCreateHandler handler,
        [FromBody] CountryCreateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [PolicyAuthorization(CountryPolicy.UPDATE), HttpPut, Route("")]
    public async Task<IActionResult> Update(
        [FromServices] ICountryUpdateHandler handler,
        [FromBody] CountryUpdateCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [PolicyAuthorization(CountryPolicy.DELETE), HttpDelete, Route("")]
    public async Task<IActionResult> Delete(
        [FromServices] ICountryDeleteHandler handler,
        [FromBody] CountryDeleteCommand command)
    {
        var response = await handler.HandleAsync(command);

        return CustomResponse(response);
    }

    [PolicyAuthorization(CountryPolicy.VIEW), HttpGet, Route("GetViewModel")]
    public async Task<IActionResult> GetViewModel(
        [FromServices] IGetCountryViewModelQueryHandler handler,
        [FromQuery] GetCountryViewModel command)
    {
        var response = await handler.HandleAsync(command);

        return OkOrNotFoundQuery(response);
    }
}
