using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Repository.Repositories;

namespace ScheduleService.Infrastructure.Repository;

public class IoCRepositories
{
    public static void AddInfrastructureRepository(IServiceCollection services)
    {
        _ = services
                /* Cache Repositories */
                .AddMemoryCache()
                .AddScoped<ICacheRepository, RedisCacheRepository>()
                //.AddScoped<ICacheRepository, InMemoryCacheRepository>()

                /* UoW Repository */
                .AddScoped<IUnitOfWork, UnitOfWork>()

                /* Data Repositories */
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<ICompanySubsidiaryRepository, CompanySubsidiaryRepository>()
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IServiceItemRepository, ServiceItemRepository>()
                .AddScoped<IServiceOrderRepository, ServiceOrderRepository>()
                .AddScoped<IServiceTypeRepository, ServiceTypeRepository>()
                .AddScoped<IStateRepository, StateRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                ;
    }
}
