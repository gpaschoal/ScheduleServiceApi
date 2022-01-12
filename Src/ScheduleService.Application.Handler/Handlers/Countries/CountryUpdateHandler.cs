﻿using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Repositories.Countries;

namespace ScheduleService.Application.Handler.Handlers.Countries;

internal class CountryUpdateHandler : HandlerBase<CountryUpdateCommand, CustomResultData>, ICountryUpdateHandler
{
    private readonly ICountryUpdateRepository _repository;

    public CountryUpdateHandler(
        IHandlerBus handlerBus,
        ICountryUpdateRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(CountryUpdateCommand request, CancellationToken cancellationToken)
    {
        if (_repository.ExistsCountryWithName(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACountryWithThisName);

        if (_repository.ExistsCountryWithExternalCode(id: request.Id, externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsACountryWithThisExternalCode);

        var entity = await _repository.GetByIdAsync(id: request.Id);
        if (entity is null)
            AddError(nameof(request.Id), ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponseAsync();

        entity.Update(name: request.Name, externalCode: request.ExternalCode);

        await _repository.UpdateAsync(entity);

        return ValidResponseAsync();
    }
}
