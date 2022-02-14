using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories.Base;

namespace ScheduleService.Domain.Core.Repositories;

public interface IUserRepository : IRepository<User>
{
    ValueTask<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}
