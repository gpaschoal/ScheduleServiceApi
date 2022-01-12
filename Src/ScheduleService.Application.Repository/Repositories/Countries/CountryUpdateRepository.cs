using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.Countries;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Countries;

internal class CountryUpdateRepository : ICountryUpdateRepository
{
    private readonly ICountryRepository _repository;

    public CountryUpdateRepository(ICountryRepository repository)
    {
        _repository = repository;
    }

    public bool ExistsCountryWithExternalCode(Guid id, string externalCode)
    {
        return _repository.ExistsCountryWithExternalCode(id, externalCode);
    }

    public bool ExistsCountryWithName(Guid id, string name)
    {
        return _repository.ExistsCountryWithName(id, name);
    }

    public ValueTask<Country?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public ValueTask UpdateAsync(Country data)
    {
        return _repository.UpdateAsync(data);
    }
}
