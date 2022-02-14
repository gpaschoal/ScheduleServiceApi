using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Repositories;
using ScheduleService.Domain.Core.Repositories.Base;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
