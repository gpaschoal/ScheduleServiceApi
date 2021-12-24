using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public User GetUserByEmailAndPassword(string email, string password)
    {
        User result = Queryable.FirstOrDefault(x => x.Email == email && x.Password == password);

        return result;
    }
}
