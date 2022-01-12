using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.Countries;

internal class CountryCreateHandler : HandlerBase<CountryCreateCommand, CustomResultData<Guid>>, ICountryCreateHandler
{
    private readonly ICountryCreateRepository _repository;

    public CountryCreateHandler(
        IHandlerBus handlerBus,
        ICountryCreateRepository repository) : base(handlerBus)
    {
        _repository = repository;
    }

    public override Task<CustomResultData<Guid>> HandleExecution(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        if (_repository.ExistsCountryWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACountryWithThisName);

        if (_repository.ExistsCountryWithExternalCode(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsACountryWithThisExternalCode);

        if (IsInvalid)
            return InvalidResponse();

        Country entity = new(request.Name, request.ExternalCode);

        _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponse(response);
    }
}
