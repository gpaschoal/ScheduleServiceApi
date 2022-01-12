using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.States;

public class StateCreateHandler : HandlerBase<StateCreateCommand, CustomResultData<Guid>>
{
    private readonly IStateCreateRepository _repository;

    public StateCreateHandler(
        IHandlerBus handlerBus,
        IStateCreateRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public override Task<CustomResultData<Guid>> HandleExecution(StateCreateCommand request, CancellationToken cancellationToken)
    {
        if (_repository.ExistsStateWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (_repository.ExistsStateWithExternalCode(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

        if (IsInvalid)
            return InvalidResponse();

        State entity = new(request.Name, request.ExternalCode, request.CountryId);

        _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponse(response);
    }
}
