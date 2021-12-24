﻿using ScheduleService.Application.Command.Commands.Countries;
using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Handler.Handlers.Countries;

public class CountryDeleteHandler : HandlerBase<CountryDeleteCommand, CustomResultData>
{
    private readonly ICountryDeleteRepository _repository;

    public CountryDeleteHandler(
        IHandlerBus handlerBus,
        ICountryDeleteRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(CountryDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(nameof(request.Id), ValidationResource.EntityNotFound);

        if (!await _repository.CheckIfIsUsedByState(request.Id))
            AddError(nameof(request.Id), ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponseAsync();

        await _repository.DeleteAsync(request.Id);

        return ValidResponseAsync();
    }
}
