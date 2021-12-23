using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Domain.Repository;
using ScheduleService.Domain.Repository.Repositories;
using ScheduleService.Infrastructure.Repository;
using ScheduleService.Infrastructure.Repository.Repositories;

namespace ScheduleService.IoC.Container;

internal class IoCRepositories
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        _ = services
                /* Cache Repositories */
                .AddMemoryCache()
                .AddScoped<ICacheRepository, InMemoryCacheRepository>()

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

        _ = services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));
    }
}
