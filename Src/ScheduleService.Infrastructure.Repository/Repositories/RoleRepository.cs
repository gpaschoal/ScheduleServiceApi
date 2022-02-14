using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.Contexts;
using ScheduleService.Infrastructure.Repository;

namespace ScheduleService.Domain.Repository.Repositories;

internal class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
