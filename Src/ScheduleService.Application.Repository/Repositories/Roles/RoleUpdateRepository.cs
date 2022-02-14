using ScheduleService.Domain.CommandHandler.Repositories.Roles;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Repository.Repositories.Roles;

public class RoleUpdateRepository : IRoleUpdateRepository
{
    public ValueTask<Role?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask UpdateAsync(Role data)
    {
        throw new NotImplementedException();
    }
}
