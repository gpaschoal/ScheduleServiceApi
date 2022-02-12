using ScheduleService.Domain.CommandHandler.Repositories.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Countries;

internal class CountryUpdateRepository : ICountryUpdateRepository
{
    private readonly ICountryRepository _repository;

    public CountryUpdateRepository(ICountryRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<bool> ExistsCountryWithExternalCodeAsync(Guid id, string externalCode)
    {
        return _repository.ExistsCountryWithExternalCodeAsync(id, externalCode);
    }

    public ValueTask<bool> ExistsCountryWithNameAsync(Guid id, string name)
    {
        return _repository.ExistsCountryWithNameAsync(id, name);
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
