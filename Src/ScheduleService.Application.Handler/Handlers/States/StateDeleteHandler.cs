using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.States;

public class StateDeleteHandler : HandlerBase<StateDeleteCommand, CustomResultData>
{
    private readonly IStateDeleteRepository _repository;

    public StateDeleteHandler(
        IHandlerBus handlerBus,
        IStateDeleteRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> HandleExecution(StateDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(ValidationResource.EntityNotFound);

        if (await _repository.CheckIfIsUsedByCity(request.Id))
            AddError(ValidationResource.ThereAreCitiesUsingThisState);

        if (IsInvalid)
            return InvalidResponseAsync();

        await _repository.DeleteAsync(request.Id);

        return ValidResponseAsync();
    }
}
