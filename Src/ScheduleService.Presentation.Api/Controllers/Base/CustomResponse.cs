using System.Dynamic;

namespace ScheduleService.Presentation.Api.Controllers.Base;

public class CustomResponse<TData> : CustomResponse
{
    public TData? Data { get; set; }
}

public class CustomResponse
{
    public bool Success { get => Errors is null; }

    public ExpandoObject? Errors { get; set; }
}