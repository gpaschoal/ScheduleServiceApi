using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.States;

internal class StateUpdateRepository : IStateUpdateRepository
{
    private readonly IStateRepository _repository;
    private readonly ICountryRepository _countryRepository;

    public StateUpdateRepository(
        IStateRepository repository,
        ICountryRepository countryRepository)
    {
        _repository = repository;
        _countryRepository = countryRepository;
    }

    public ValueTask<bool> CheckIfCountryExists(Guid countryId)
    {
        return _countryRepository.CheckIfExistByIdAsync(countryId);
    }

    public ValueTask<bool> ExistsStateWithExternalCodeAsync(Guid id, string externalCode)
    {
        return _repository.ExistsStateWithExternalCodeAsync(id, externalCode);
    }

    public ValueTask<bool> ExistsStateWithNameAsync(Guid id, string name)
    {
        return _repository.ExistsStateWithNameAsync(id, name);
    }

    public ValueTask<State?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public ValueTask UpdateAsync(State data)
    {
        return _repository.UpdateAsync(data);
    }
}
