using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

internal class StateCreateRepository : IStateCreateRepository
{
    private readonly IStateRepository _repository;
    private readonly ICountryRepository _countryRepository;

    public StateCreateRepository(
        IStateRepository repository,
        ICountryRepository countryRepository)
    {
        _repository = repository;
        _countryRepository = countryRepository;
    }

    public ValueTask AddAsync(State data)
    {
        return _repository.AddAsync(data);
    }

    public ValueTask<bool> CheckIfCountryExists(Guid countryId)
    {
        return _countryRepository.CheckIfExistByIdAsync(countryId);
    }

    public ValueTask<bool> ExistsStateWithExternalCodeAsync(string externalCode)
    {
        return _repository.ExistsStateWithExternalCodeAsync(externalCode);
    }

    public ValueTask<bool> ExistsStateWithNameAsync(string name)
    {
        return _repository.ExistsStateWithNameAsync(name);
    }
}
