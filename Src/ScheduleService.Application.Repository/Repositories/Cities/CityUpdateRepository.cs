using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Cities;

internal class CityUpdateRepository : ICityUpdateRepository
{
    private readonly ICityRepository _repository;
    private readonly IStateRepository _stateRepository;

    public CityUpdateRepository(
        ICityRepository repository, 
        IStateRepository stateRepository)
    {
        _repository = repository;
        _stateRepository = stateRepository;
    }

    public ValueTask<bool> CheckIfStateExists(Guid countryId)
    {
        return _stateRepository.CheckIfExistByIdAsync(countryId);
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
