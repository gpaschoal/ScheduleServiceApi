using ScheduleService.Application.CommandHandler.Validators.Countries;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Countries;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.CommandHandler.Repositories.Countries;

namespace ScheduleService.Application.CommandHandler.Handlers.Countries;

internal class CountryUpdateHandler : CommandHandler<CountryUpdateCommand, CustomResultData>, ICountryUpdateHandler
{
    private readonly ICountryUpdateRepository _repository;

    public CountryUpdateHandler(ICountryUpdateRepository repository)
    {
        _repository = repository;
    }

    public async override ValueTask<CustomResultData> HandleAsync(CountryUpdateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<CountryUpdateValidator>(request))
            return InvalidResponse();

        if (await _repository.ExistsCountryWithNameAsync(id: request.Id, name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACountryWithThisName);

        if (await _repository.ExistsCountryWithExternalCodeAsync(id: request.Id, externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsACountryWithThisExternalCode);

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
