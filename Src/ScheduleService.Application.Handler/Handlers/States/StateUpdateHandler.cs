﻿using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Handler.Handlers.States;

public class StateUpdateHandler : HandlerBase<StateUpdateCommand, CustomResultData>
{
    private readonly IStateUpdateRepository _repository;

    public StateUpdateHandler(
        IHandlerBus handlerBus,
        IStateUpdateRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(StateUpdateCommand request, CancellationToken cancellationToken)
    {
        if (_repository.ExistsStateWithName(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (_repository.ExistsStateWithExternalCode(id: request.Id, externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

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
