using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Handlers.Countries;
using ScheduleService.Domain.Handler.Repositories.Countries;

namespace ScheduleService.Application.Handler.Handlers.Countries;

internal class CountryCreateHandler : RequestHandler<CountryCreateCommand, CustomResultData<Guid>>, ICountryCreateHandler
{
    private readonly ICountryCreateRepository _repository;

    public CountryCreateHandler(ICountryCreateRepository repository)
    {
        _repository = repository;
    }

    public override Task<CustomResultData<Guid>> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<CountryCreateValidator>(request))
            return InvalidResponseAsync();

        if (_repository.ExistsCountryWithName(name: request.Name))
            AddError(nameof(request.Name), ValidationResource.AlreadyExistsACountryWithThisName);

        if (_repository.ExistsCountryWithExternalCode(externalCode: request.ExternalCode))
            AddError(nameof(request.ExternalCode), ValidationResource.AlreadyExistsACountryWithThisExternalCode);

        if (IsInvalid)
            return InvalidResponseAsync();

        Country entity = new(request.Name, request.ExternalCode);

        _repository.AddAsync(entity);

        CustomResultData<Guid> response = new(entity.Id);

        return ValidResponseAsync(response);
    }
}
