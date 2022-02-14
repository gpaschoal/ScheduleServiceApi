using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.RolePolicies;

public class RolePolicyUpdateRepository : IRolePolicyUpdateRepository
{
    private readonly IRolePolicyRepository _repository;

    public RolePolicyUpdateRepository(IRolePolicyRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<RolePolicy?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }

    public ValueTask UpdateAsync(RolePolicy data)
    {
        return _repository.UpdateAsync(data);
    }
}
