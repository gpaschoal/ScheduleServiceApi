using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Handler.Handlers.Cities;

public class CityDeleteHandler : HandlerBase<CityDeleteCommand, CustomResultData>
{
    private readonly ICityDeleteRepository _repository;

    public CityDeleteHandler(
        IHandlerBus handlerBus, 
        ICityDeleteRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(CityDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(ValidationResource.EntityNotFound);

        if (IsInvalid)
            return InvalidResponseAsync();

        await _repository.DeleteAsync(request.Id);

        return ValidResponseAsync();
    }
}
