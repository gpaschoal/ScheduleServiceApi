using ScheduleService.Application.CommandValidator.Validators.States;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.States;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.CommandHandler.Handlers.States;

internal class StateCreateHandler : CommandHandler<StateCreateCommand, CustomResultData<Guid>>, IStateCreateHandler
{
    private readonly IStateCreateRepository _repository;

    public StateCreateHandler(IStateCreateRepository repository)
    {
        _repository = repository;
    }

    public override async Task<CustomResultData<Guid>> HandleAsync(StateCreateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateCreateValidator>(request))
            return InvalidResponse();

        if (await _repository.ExistsStateWithNameAsync(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (await _repository.ExistsStateWithExternalCodeAsync(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

        if (!await _repository.CheckIfCountryExists(countryId: request.CountryId))
            AddError(ValidationResource.CountryNotFound);

        if (IsInvalid)
            return InvalidResponse();

        State entity = new(request.Name, request.ExternalCode, request.CountryId);

        await _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponse(response);
    }
}
