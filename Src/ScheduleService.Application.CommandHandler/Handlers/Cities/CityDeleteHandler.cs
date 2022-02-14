using ScheduleService.Application.CommandValidator.Validators.Cities;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;

namespace ScheduleService.Application.CommandHandler.Handlers.Cities;

internal class CityDeleteHandler : CommandHandler<CityDeleteCommand, CustomResultData>, ICityDeleteHandler
{
    private readonly ICityDeleteRepository _repository;

    public CityDeleteHandler(ICityDeleteRepository repository)
    {
        _repository = repository;
    }

    public async override ValueTask<CustomResultData> HandleAsync(CityDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<CityDeleteValidator>(request))
            return InvalidResponse();

        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponse();

        await _repository.DeleteAsync(request.Id);

        return ValidResponse();
    }
}
