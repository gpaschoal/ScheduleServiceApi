using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

public class CompanySubsidiaryRepository : RepositoryBase<CompanySubsidiary>, ICompanySubsidiaryRepository
{
    public CompanySubsidiaryRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
