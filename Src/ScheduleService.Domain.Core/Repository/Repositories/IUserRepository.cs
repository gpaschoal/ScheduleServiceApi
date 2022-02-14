using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface IUserRepository : IRepository<User>
{
    ValueTask<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}
