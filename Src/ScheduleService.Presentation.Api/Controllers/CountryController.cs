using Microsoft.AspNetCore.Mvc;

namespace ScheduleService.Presentation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    //private readonly IMediator _mediator;

    //public CountryController(IMediator mediator)
    //{
    //    _mediator = mediator;
    //}

    //[Authorize, HttpPost, Route("")]
    //public async Task<IActionResult> Create(
    //   [FromBody] CountryCreateCommand command)
    //{
    //    var response = await _mediator.Send(command);

    //    if (response.IsValid)
    //        return Ok(response);
    //    return BadRequest(response);
    //}

    //[Authorize, HttpPut, Route("")]
    //public async Task<IActionResult> Update(
    //    [FromBody] CountryUpdateCommand command)
    //{
    //    var response = await _mediator.Send(command);

    //    if (response.IsValid)
    //        return Ok(response);
    //    return BadRequest(response);
    //}

    //[Authorize, HttpDelete, Route("")]
    //public async Task<IActionResult> Delete(
    //    [FromBody] CountryDeleteCommand command)
    //{
    //    var response = await _mediator.Send(command);

    //    if (response.IsValid)
    //        return Ok(response);
    //    return BadRequest(response);
    //}
}
