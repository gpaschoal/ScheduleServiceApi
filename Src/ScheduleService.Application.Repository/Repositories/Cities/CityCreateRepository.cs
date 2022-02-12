using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

internal class CityCreateRepository : ICityCreateRepository
{
    private readonly ICityRepository _repository;
    private readonly IStateRepository _stateRepository;

    public CityCreateRepository(ICityRepository repository)
    {
        _repository = repository;
    }

    public ValueTask AddAsync(City data)
    {
        return _repository.AddAsync(data);
    }

    public async ValueTask<bool> CheckIfStateExists(Guid countryId)
    {
        return await _stateRepository.CheckIfExistByIdAsync(countryId);
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
