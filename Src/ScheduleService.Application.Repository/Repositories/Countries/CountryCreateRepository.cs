using ScheduleService.Domain.CommandHandler.Repositories.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Countries;

internal class CountryCreateRepository : ICountryCreateRepository
{
    private readonly ICountryRepository _repository;

    public CountryCreateRepository(ICountryRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(Country data)
    {
        return _repository.AddAsync(data);
    }

    public ValueTask<bool> ExistsCountryWithExternalCodeAsync(string externalCode)
    {
        return _repository.ExistsCountryWithExternalCodeAsync(externalCode);
    }

    public ValueTask<bool> ExistsCountryWithName(string name)
    {
        return _repository.ExistsCountryWithNameAsync(name);
    }
}
