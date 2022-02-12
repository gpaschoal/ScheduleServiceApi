using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Handlers.States;
using ScheduleService.Domain.Handler.Repositories.States;

namespace ScheduleService.Application.Handler.Handlers.States;

internal class StateUpdateHandler : RequestHandler<StateUpdateCommand, CustomResultData>, IStateUpdateHandler
{
    private readonly IStateUpdateRepository _repository;

    public StateUpdateHandler(IStateUpdateRepository repository)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> Handle(StateUpdateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateUpdateValidator>(request))
            return InvalidResponse();

        if (_repository.ExistsStateWithName(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (_repository.ExistsStateWithExternalCode(id: request.Id, externalCode: request.ExternalCode))
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
