using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories.Base;
using ScheduleService.Infrastructure.Context.Contexts;
using ScheduleService.Infrastructure.Repository;

namespace ScheduleService.Domain.Core.Repositories;

internal class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
