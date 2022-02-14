using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;
using ScheduleService.Domain.Core.Repositories.Base;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }

    public async ValueTask<User?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        var result = await Queryable.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

        return result;
    }
}
