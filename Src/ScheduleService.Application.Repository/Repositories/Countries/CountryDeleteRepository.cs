using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Countries;

public class CountryDeleteRepository : ICountryDeleteRepository
{
    private readonly ICountryRepository _repository;

    public CountryDeleteRepository(ICountryRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<bool> CheckIfExistByIdAsync(Guid id)
    {
        return _repository.CheckIfExistByIdAsync(id);
    }

    public ValueTask<bool> CheckIfIsUsedByState(Guid id)
    {
        return _repository.CheckIfIsUsedByState(id);
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }

    public ValueTask<Country?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}
