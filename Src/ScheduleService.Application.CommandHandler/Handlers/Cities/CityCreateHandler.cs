﻿using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.CommandHandler.Handlers.Cities;

internal class CityCreateHandler : RequestHandler<CityCreateCommand, CustomResultData<Guid>>, ICityCreateHandler
{
    private readonly ICityCreateRepository _repository;

    public CityCreateHandler(ICityCreateRepository repository)
    {
        _repository = repository;
    }

    public override async Task<CustomResultData<Guid>> Handle(CityCreateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<CityCreateValidator>(request))
            return InvalidResponse();

        if (_repository.ExistsCityWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACityWithThisName);

        if (_repository.ExistsCityWithExternalCode(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

        if (!await _repository.CheckIfStateExists(countryId: request.StateId))
            AddError(ValidationResource.StateNotFound);

        if (IsInvalid)
            return InvalidResponse();

        City entity = new(request.Name, request.ExternalCode, request.StateId);

        _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponse(response);
    }
}
