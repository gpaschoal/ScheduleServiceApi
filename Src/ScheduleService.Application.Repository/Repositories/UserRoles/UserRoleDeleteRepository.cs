using ScheduleService.Domain.CommandHandler.Repositories.UserRoles;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;

namespace ScheduleService.Application.Repository.Repositories.UserRoles;

public class UserRoleDeleteRepository : IUserRoleDeleteRepository
{
    private readonly IUserRoleRepository _repository;

    public UserRoleDeleteRepository(IUserRoleRepository repository)
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

    public ValueTask<UserRole?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}
