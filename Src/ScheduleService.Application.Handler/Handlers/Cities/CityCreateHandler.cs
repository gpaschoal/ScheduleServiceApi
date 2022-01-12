using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.Cities;

internal class CityCreateHandler : HandlerBase<CityCreateCommand, CustomResultData<Guid>>, ICityCreateHandler
{
    private readonly ICityCreateRepository _repository;

    public CityCreateHandler(
        IHandlerBus handlerBus,
        ICityCreateRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public override Task<CustomResultData<Guid>> HandleExecution(CityCreateCommand request, CancellationToken cancellationToken)
    {
        if (_repository.ExistsCityWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACityWithThisName);

        if (_repository.ExistsCityWithExternalCode(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsAStateWithThisExternalCode);

        if (IsInvalid)
            return InvalidResponse();

        City entity = new(request.Name, request.ExternalCode, request.StateId);

        _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponse(response);
    }
}
