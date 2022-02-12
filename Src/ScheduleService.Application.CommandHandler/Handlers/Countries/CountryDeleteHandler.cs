using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.CommandHandler.Repositories.Countries;

namespace ScheduleService.Application.CommandHandler.Handlers.Countries;

internal class CountryDeleteHandler : RequestHandler<CountryDeleteCommand, CustomResultData>, ICountryDeleteHandler
{
    private readonly ICountryDeleteRepository _repository;

    public CountryDeleteHandler(ICountryDeleteRepository repository)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> Handle(CountryDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<CountryDeleteValidator>(request))
            return InvalidResponse();

        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(nameof(request.Id), ValidationResource.EntityNotFound);

        if (await _repository.CheckIfIsUsedByState(request.Id))
            AddError(ValidationResource.ThereAreStatesUsingThisCountry);

        if (IsInvalid)
            return InvalidResponse();

        await _repository.DeleteAsync(request.Id);

        return ValidResponse();
    }
}
