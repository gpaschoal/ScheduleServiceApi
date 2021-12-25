﻿using EasyValidation.Core.Results;
using MediatR;

namespace ScheduleService.Application.Handler.Handlers;
public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResultData, new()
{
    private readonly IHandlerBus _handlerBus;
    private readonly TResponse _response;
    public bool IsValid { get => _response.IsValid; }
    public bool IsInvalid { get => !IsValid; }

    public HandlerBase(IHandlerBus handlerBus)
    {
        _handlerBus = handlerBus;
        _response = new();
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var resultDataValidated = _handlerBus.Validator.ValidateCommand(request);
        if (resultDataValidated is not null && resultDataValidated.IsInvalid)
        {
            TResponse result = new();
            var fieldErrorsDic = resultDataValidated.FieldErrors.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var assignFieldErrors = resultDataValidated.AssignFieldErrors.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            result.IncoporateErrors(fieldErrorsDic, assignFieldErrors);
            return Task.FromResult(result);
        }

        return HandleExecution(request, cancellationToken);
    }

    public abstract Task<TResponse> HandleExecution(TRequest request, CancellationToken cancellationToken);

    public void AddError(string message)
    {
        _response.AddMessageError(message);
    }

    public void AddError(string key, string message)
    {
        _response.AddFieldError(key, message);
    }

    public Task<TResponse> InvalidResponse() => Task.FromResult(_response);
    public TResponse InvalidResponseAsync() => _response;

    public Task<TResponse> ValidResponse() => Task.FromResult(new TResponse());
    public TResponse ValidResponseAsync() => new();

    public Task<TResponse> ValidResponse(TResponse response) => Task.FromResult(response);
    public TResponse ValidResponseAsync(TResponse response) => response;
}