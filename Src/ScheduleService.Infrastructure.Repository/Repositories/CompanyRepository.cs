using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
