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

    public ValueTask<bool> CheckIfStateExists(Guid countryId)
    {
        return _stateRepository.CheckIfExistByIdAsync(countryId);
    }

    public ValueTask<bool> ExistsCityWithExternalCodeAsync(string externalCode)
    {
        return _repository.ExistsCityWithExternalCodeAsync(externalCode);
    }

    public ValueTask<bool> ExistsCityWithNameAsync(string name)
    {
        return _repository.ExistsCityWithNameAsync(name);
    }
}
