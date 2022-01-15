namespace ScheduleService.Application.Shared;

public class CustomResultData<T> : CustomResultData where T : new()
{
    public T Data { get; set; }
    public CustomResultData() : base()
    {
        Data = new T();
    }

    public CustomResultData(T data)
    {
        Data = data;
    }
}

public class CustomResultData
{
    private readonly IDictionary<string, IList<string>> _errors;
    public bool IsValid { get => !_errors.Any(); }
    public IReadOnlyDictionary<string, IList<string>> Errors => _errors.ToDictionary(kv => kv.Key, kv => kv.Value);

    public CustomResultData()
    {
        _errors = new Dictionary<string, IList<string>>();
    }

    public void AddError(string key, string errorMessage)
    {
        if (!_errors.ContainsKey(key))
            _errors.Add(key, new List<string>());

        if (!_errors[key].Contains(errorMessage))
            _errors[key].Add(errorMessage);
    }

    public void AddErrors(string key, IList<string> errorsMessages)
    {
        if (!_errors.ContainsKey(key))
            _errors.Add(key, new List<string>());

        foreach (var errorMessage in errorsMessages.Distinct())
        {
            if (_errors[key].Contains(errorMessage))
                continue;

            _errors[key].Add(errorMessage);
        }
    }
}
