using FluentValidation;
using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands;

namespace ScheduleService.Domain.Handler.Handlers;
public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : CustomResultData, new()
{
    private readonly TResponse _response;
    public bool IsInvalid { get => !_response.IsValid; }

    public RequestHandler()
    {
        _response = new();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TValidator"></typeparam>
    /// <param name="command"></param>
    /// <returns>Return if isValid</returns>
    public bool Validate<TValidator>(TRequest command) where TValidator : AbstractValidator<TRequest>, new()
    {
        var validator = new TValidator();
        var result = validator.Validate(command);

        if (result.IsValid)
            return true;

        for (int i = 0; i < result.Errors.Count; i++)
            AddError(result.Errors[i].PropertyName, result.Errors[i].ErrorMessage);

        return false;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    public void AddError(string message) => _response.AddError("&___message", message);

    public void AddError(string key, string message) => _response.AddError(key, message);

    public Task<TResponse> InvalidResponseAsync() => Task.FromResult(_response);
    public TResponse InvalidResponse() => _response;

    public Task<TResponse> ValidResponseAsync() => Task.FromResult(new TResponse());
    public TResponse ValidResponse() => new();

    public Task<TResponse> ValidResponseAsync(TResponse response) => Task.FromResult(response);
    public TResponse ValidResponse(TResponse response) => response;
}
