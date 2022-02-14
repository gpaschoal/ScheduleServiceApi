using ScheduleService.Domain.CommandHandler.Repositories.Roles;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository.Repositories;

namespace ScheduleService.Application.Repository.Repositories.Roles;

public class RoleDeleteRepository : IRoleDeleteRepository
{
    private readonly IRoleRepository _repository;

    public RoleDeleteRepository(IRoleRepository repository)
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

    public ValueTask<Role?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}
