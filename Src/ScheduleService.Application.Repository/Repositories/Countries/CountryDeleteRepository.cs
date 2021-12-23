using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Countries;

public class CountryDeleteRepository : ICountryDeleteRepository
{
    private readonly ICountryRepository _repository;

    public CountryDeleteRepository(ICountryRepository repository)
    {
        _repository = repository;
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }
}
