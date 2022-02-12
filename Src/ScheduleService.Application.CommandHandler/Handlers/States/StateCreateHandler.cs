using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.CommandValidator.Validators.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.CommandHandler.Handlers.States;

internal class StateCreateHandler : RequestHandler<StateCreateCommand, CustomResultData<Guid>>, IStateCreateHandler
{
    private readonly IStateCreateRepository _repository;

    public StateCreateHandler(IStateCreateRepository repository)
    {
        _repository = repository;
    }

    public override async Task<CustomResultData<Guid>> Handle(StateCreateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateCreateValidator>(request))
            return InvalidResponse();

        if (_repository.ExistsStateWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (_repository.ExistsStateWithExternalCode(externalCode: request.ExternalCode))
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
