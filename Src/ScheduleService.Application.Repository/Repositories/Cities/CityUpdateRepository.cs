using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

internal class CityUpdateRepository : ICityUpdateRepository
{
    private readonly ICityRepository _repository;

    public CityUpdateRepository(ICityRepository repository)
    {
        _repository = repository;
    }

    public bool ExistsCityWithExternalCode(Guid id, string externalCode)
    {
        return _repository.ExistsCityWithExternalCode(id, externalCode);
    }

    public bool ExistsCityWithName(Guid id, string name)
    {
        return _repository.ExistsCityWithName(id, name);
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
