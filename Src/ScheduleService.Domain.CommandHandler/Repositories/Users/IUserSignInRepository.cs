using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.Users;

public interface IUserSignInRepository : IHandlerRepository<User>
{
    ValueTask<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}
