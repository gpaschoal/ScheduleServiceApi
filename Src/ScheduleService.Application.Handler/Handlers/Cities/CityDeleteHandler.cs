using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Repositories.Cities;

namespace ScheduleService.Application.Handler.Handlers.Cities;

internal class CityDeleteHandler : HandlerBase<CityDeleteCommand, CustomResultData>, ICityDeleteHandler
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
