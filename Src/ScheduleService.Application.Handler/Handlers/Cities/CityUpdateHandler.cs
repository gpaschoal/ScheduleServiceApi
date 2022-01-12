using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Repositories.Cities;

namespace ScheduleService.Application.Handler.Handlers.Cities;

internal class CityUpdateHandler : HandlerBase<CityUpdateCommand, CustomResultData>, ICityUpdateHandler
{
    private readonly ICityUpdateRepository _repository;

    public CityUpdateHandler(
        IHandlerBus handlerBus,
        ICityUpdateRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(CityUpdateCommand request, CancellationToken cancellationToken)
    {
        if (_repository.ExistsCityWithName(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACityWithThisName);

        if (_repository.ExistsCityWithExternalCode(id: request.Id, externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsACityWithThisExternalCode);

        var entity = await _repository.GetByIdAsync(id: request.Id);
        if (entity is null)
            AddError(ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponseAsync();

        entity.Update(name: request.Name, externalCode: request.ExternalCode);

        await _repository.UpdateAsync(entity);

        return ValidResponseAsync();
    }
}
