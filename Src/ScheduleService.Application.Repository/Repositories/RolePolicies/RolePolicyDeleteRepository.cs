using ScheduleService.Domain.CommandHandler.Repositories.RolePolicies;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.RolePolicies;

public class RolePolicyDeleteRepository : IRolePolicyDeleteRepository
{
    private readonly IRolePolicyRepository _repository;

    public RolePolicyDeleteRepository(IRolePolicyRepository repository)
    {
        _repository = repository;
    }

    public ValueTask<bool> CheckIfExistByIdAsync(Guid id)
    {
        return _repository.CheckIfExistByIdAsync(id);
    }

    public ValueTask DeleteAsync(Guid id)
    {
        return _repository.DeleteAsync(id);
    }

    public ValueTask<RolePolicy?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}
