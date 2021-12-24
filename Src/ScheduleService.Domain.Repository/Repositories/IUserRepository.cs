using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Repository.Repositories;

public interface IUserRepository : IRepository<User>
{
    User GetUserByEmailAndPassword(string email, string password);
}
