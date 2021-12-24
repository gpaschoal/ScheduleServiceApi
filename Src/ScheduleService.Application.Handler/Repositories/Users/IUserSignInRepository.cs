using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Repositories.Users;

public interface IUserSignInRepository : IHandlerRepository<User>
{
    User GetUserByEmailAndPassword(string email, string password);
}
