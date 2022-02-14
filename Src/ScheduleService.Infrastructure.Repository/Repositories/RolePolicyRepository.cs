using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories.Base;
using ScheduleService.Infrastructure.Context.Contexts;
using ScheduleService.Infrastructure.Repository;

namespace ScheduleService.Domain.Core.Repositories;

public class RolePolicyRepository : RepositoryBase<RolePolicy>, IRolePolicyRepository
{
    public RolePolicyRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
