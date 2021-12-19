using EasyValidation.Core.Results;

namespace ScheduleService.Application.Shared;
public class CustomResultData<T> : ResultData<T> where T : new()
{
    public CustomResultData() : base()
    { }

    public CustomResultData(T data) : base(data)
    { }
}

public class CustomResultData : ResultData
{ }
