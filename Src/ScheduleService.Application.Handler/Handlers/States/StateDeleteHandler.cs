using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Handlers.States;
using ScheduleService.Domain.Handler.Repositories.States;

namespace ScheduleService.Application.Handler.Handlers.States;

internal class StateDeleteHandler : RequestHandler<StateDeleteCommand, CustomResultData>, IStateDeleteHandler
{
    private readonly IStateDeleteRepository _repository;

    public StateDeleteHandler(IStateDeleteRepository repository)
    {
        _repository = repository;
    }

    public async override Task<CustomResultData> Handle(StateDeleteCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateDeleteValidator>(request))
            return InvalidResponse();

        if (!await _repository.CheckIfExistByIdAsync(request.Id))
            AddError(ValidationResource.EntityNotFound);

        if (await _repository.CheckIfIsUsedByCity(request.Id))
            AddError(ValidationResource.ThereAreCitiesUsingThisState);

        if (IsInvalid)
            return InvalidResponse();

        await _repository.DeleteAsync(request.Id);

        return ValidResponse();
    }
}
