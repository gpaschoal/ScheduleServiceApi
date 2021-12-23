using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

public class CityDeleteRepository : ICityDeleteRepository
{
    private readonly ICityRepository _repository;

    public CityDeleteRepository(ICityRepository repository)
    {
        _repository = repository;
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }
}
