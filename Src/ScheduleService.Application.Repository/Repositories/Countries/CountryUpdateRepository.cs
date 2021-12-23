using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Countries;

public class CountryUpdateRepository : ICountryUpdateRepository
{
    private readonly ICountryRepository _repository;

    public CountryUpdateRepository(ICountryRepository repository)
    {
        _repository = repository;
    }

    public ValueTask UpdateAsync(Country data)
    {
        return _repository.UpdateAsync(data);
    }
}
