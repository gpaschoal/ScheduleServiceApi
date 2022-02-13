using Microsoft.AspNetCore.Mvc;
using ScheduleService.Application.Shared;
using System.Dynamic;

namespace ScheduleService.Presentation.Api.Controllers.Base;

public abstract class MainController : ControllerBase
{
    public IActionResult CustomResponse(CustomResultData customResultData)
    {
        CustomResponse response = new();

        if (customResultData.IsValid)
            return Ok(response);

        response.Errors = MapToExpandoObject(customResultData.Errors);

        return BadRequest(response);
    }

    public IActionResult CustomResponse<TData>(CustomResultData<TData> customResultData) where TData : new()
    {
        CustomResponse<TData> response = new();

        if (customResultData.IsValid)
        {
            response.Data = customResultData.Data;
            return Ok(response);
        }

        response.Errors = MapToExpandoObject(customResultData.Errors);

        return BadRequest(response);
    }

    private static ExpandoObject MapToExpandoObject(IReadOnlyDictionary<string, IList<string>> errors)
    {
        var result = new ExpandoObject();

        foreach (var error in errors)
            result.TryAdd(error.Key, error.Value.FirstOrDefault());

        return result;
    }

    public IActionResult OkOrNotFoundQuery(object? response)
    {
        if (response is null)
            return NotFound();

        return Ok(response);
    }
}
