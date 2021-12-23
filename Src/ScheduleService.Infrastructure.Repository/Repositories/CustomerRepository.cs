using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(ScheduleServiceDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
