using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

public class CityUpdateRepository : ICityUpdateRepository
{
    private readonly ICityRepository _repository;

    public CityUpdateRepository(ICityRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<City?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public ValueTask UpdateAsync(City data)
    {
        return _repository.UpdateAsync(data);
    }
}
