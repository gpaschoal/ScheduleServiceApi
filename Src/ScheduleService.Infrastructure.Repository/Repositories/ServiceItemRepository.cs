﻿using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository.Repositories;

internal class ServiceItemRepository : RepositoryBase<ServiceItem>, IServiceItemRepository
{
    public ServiceItemRepository(AppDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
    { }
}
