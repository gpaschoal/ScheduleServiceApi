using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Handlers.States;
using ScheduleService.Domain.Handler.Repositories.States;

namespace ScheduleService.Application.Handler.Handlers.States;

internal class StateCreateHandler : RequestHandler<StateCreateCommand, CustomResultData<Guid>>, IStateCreateHandler
{
    private readonly IStateCreateRepository _repository;

    public StateCreateHandler(IStateCreateRepository repository)
    {
        _repository = repository;
    }

    public override Task<CustomResultData<Guid>> Handle(StateCreateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<StateCreateValidator>(request))
            return InvalidResponseAsync();

        if (_repository.ExistsStateWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsAStateWithThisName);

        if (_repository.ExistsStateWithExternalCode(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

        if (IsInvalid)
            return InvalidResponseAsync();

        State entity = new(request.Name, request.ExternalCode, request.CountryId);

        _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponseAsync(response);
    }
}
