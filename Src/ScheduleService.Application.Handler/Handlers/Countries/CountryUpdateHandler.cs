using ScheduleService.Application.Command.Commands.Countries;
using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Handler.Handlers.Countries;

public class CountryUpdateHandler : HandlerBase<CountryUpdateCommand, CustomResultData>
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
