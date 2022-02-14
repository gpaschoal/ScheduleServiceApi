using ScheduleService.Domain.Core.Entities;
using ScheduleService.Infrastructure.Context.Contexts;
using ScheduleService.Infrastructure.Repository;

namespace ScheduleService.Domain.Repository.Repositories;

public class RolePolicyRepository : RepositoryBase<RolePolicy>, IRolePolicyRepository
{
    public RolePolicyRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
