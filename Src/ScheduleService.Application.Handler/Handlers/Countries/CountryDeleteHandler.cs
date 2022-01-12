using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Repositories.Countries;

namespace ScheduleService.Application.Handler.Handlers.Countries;

internal class CountryDeleteHandler : HandlerBase<CountryDeleteCommand, CustomResultData>, ICountryDeleteHandler
{
    private readonly ICountryDeleteRepository _repository;

    public CountryDeleteHandler(
        IHandlerBus handlerBus,
        ICountryDeleteRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(CountryDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(nameof(request.Id), ValidationResource.EntityNotFound);

        if (await _repository.CheckIfIsUsedByState(request.Id))
            AddError(ValidationResource.ThereAreStatesUsingThisCountry);

        if (IsInvalid)
            return InvalidResponseAsync();

        await _repository.DeleteAsync(request.Id);

        return ValidResponseAsync();
    }
}
