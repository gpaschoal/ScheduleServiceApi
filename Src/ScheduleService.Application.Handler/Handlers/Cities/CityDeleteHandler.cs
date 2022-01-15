using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Handlers.Cities;
using ScheduleService.Domain.Handler.Repositories.Cities;

namespace ScheduleService.Application.Handler.Handlers.Cities;

internal class CityDeleteHandler : RequestHandler<CityDeleteCommand, CustomResultData>, ICityDeleteHandler
{
    private readonly ICityDeleteRepository _repository;

    public CityDeleteHandler(ICityDeleteRepository repository)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> Handle(CityDeleteCommand request, CancellationToken cancellationToken)
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
