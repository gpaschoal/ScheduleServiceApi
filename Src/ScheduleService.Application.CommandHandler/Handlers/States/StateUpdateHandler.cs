using ScheduleService.Application.CommandValidator.Validators.States;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.States;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.CommandHandler.Repositories.States;

namespace ScheduleService.Application.CommandHandler.Handlers.States;

internal class StateUpdateHandler : CommandHandler<StateUpdateCommand, CustomResultData>, IStateUpdateHandler
{
    private readonly IStateUpdateRepository _repository;

    public StateUpdateHandler(IStateUpdateRepository repository)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleAsync(StateUpdateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateUpdateValidator>(request))
            return InvalidResponse();

        if (await _repository.ExistsStateWithNameAsync(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (await _repository.ExistsStateWithExternalCodeAsync(id: request.Id, externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

        if (!await _repository.CheckIfCountryExists(countryId: request.CountryId))
            AddError(ValidationResource.CountryNotFound);

        var entity = await _repository.GetByIdAsync(id: request.Id);
        if (entity is null)
            AddError(nameof(request.Id), ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponse();

        entity.Update(name: request.Name, externalCode: request.ExternalCode);

        await _repository.UpdateAsync(entity);

        return ValidResponse();
    }
}
