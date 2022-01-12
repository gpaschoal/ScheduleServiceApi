using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Handler.Repositories.Users;

public interface IUserSignInRepository : IHandlerRepository<User>
{
    User GetUserByEmailAndPassword(string email, string password);
}
