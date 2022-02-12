using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.CommandValidator.Validators.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;

namespace ScheduleService.Application.CommandHandler.Handlers.Cities;

internal class CityUpdateHandler : RequestHandler<CityUpdateCommand, CustomResultData>, ICityUpdateHandler
{
    private readonly ICityUpdateRepository _repository;

    public CityUpdateHandler(ICityUpdateRepository repository)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<CityUpdateValidator>(request))
            return InvalidResponse();

        if (_repository.ExistsCityWithName(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACityWithThisName);

        if (_repository.ExistsCityWithExternalCode(id: request.Id, externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsACityWithThisExternalCode);

        if (!await _repository.CheckIfStateExists(countryId: request.StateId))
            AddError(ValidationResource.StateNotFound);

        var entity = await _repository.GetByIdAsync(id: request.Id);
        if (entity is null)
            AddError(ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponse();

        entity.Update(name: request.Name, externalCode: request.ExternalCode);

        await _repository.UpdateAsync(entity);

        return ValidResponse();
    }
}
