using ScheduleService.Application.CommandHandler.Validators.States;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.States;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.CommandHandler.Repositories.States;

namespace ScheduleService.Application.CommandHandler.Handlers.States;

internal class StateDeleteHandler : CommandHandler<StateDeleteCommand, CustomResultData>, IStateDeleteHandler
{
    private readonly IStateDeleteRepository _repository;

    public StateDeleteHandler(IStateDeleteRepository repository)
    {
        _repository = repository;
    }

    public async override ValueTask<CustomResultData> HandleAsync(StateDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateDeleteValidator>(request))
            return InvalidResponse();

        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(ValidationResource.EntityNotFound);

        if (await _repository.CheckIfIsUsedByCityAsync(request.Id))
            AddError(ValidationResource.ThereAreCitiesUsingThisState);

        if (IsInvalid)
            return InvalidResponse();

        await _repository.DeleteAsync(request.Id);

        return ValidResponse();
    }
}
