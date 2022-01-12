using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.Countries;
using ScheduleService.Domain.Repository.Repositories;

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

    public bool ExistsCountryWithExternalCode(string externalCode)
    {
        return _repository.ExistsCountryWithExternalCode(externalCode);
    }

    public bool ExistsCountryWithName(string name)
    {
        return _repository.ExistsCountryWithName(name);
    }
}
