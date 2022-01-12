using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

internal class CityCreateRepository : ICityCreateRepository
{
    private readonly ICityRepository _repository;

    public CityCreateRepository(ICityRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(City data)
    {
        return _repository.AddAsync(data);
    }

    public bool ExistsCityWithExternalCode(string externalCode)
    {
        return _repository.ExistsCityWithExternalCode(externalCode);
    }

    public bool ExistsCityWithName(string name)
    {
        return _repository.ExistsCityWithName(name);
    }
}
