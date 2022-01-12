using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Application.Handler.Repositories.Users;
using ScheduleService.Application.Repository.Repositories.Cities;
using ScheduleService.Application.Repository.Repositories.Countries;
using ScheduleService.Application.Repository.Repositories.States;
using ScheduleService.Application.Repository.Repositories.Users;

namespace ScheduleService.Application.Repository;

public static class IoCRepositoriesApplication
{
    public static void AddApplicationRepository(IServiceCollection services)
    {
        _ = services
                /* City */
                .AddScoped<ICityCreateRepository, CityCreateRepository>()
                .AddScoped<ICityUpdateRepository, CityUpdateRepository>()
                .AddScoped<ICityDeleteRepository, CityDeleteRepository>()

                /* State */
                .AddScoped<IStateCreateRepository, StateCreateRepository>()
                .AddScoped<IStateUpdateRepository, StateUpdateRepository>()
                .AddScoped<IStateDeleteRepository, StateDeleteRepository>()

                /* Country */
                .AddScoped<ICountryCreateRepository, CountryCreateRepository>()
                .AddScoped<ICountryUpdateRepository, CountryUpdateRepository>()
                .AddScoped<ICountryDeleteRepository, CountryDeleteRepository>()

                /* User */
                .AddScoped<IUserSignInRepository, UserSignInRepository>()
                ;
    }
}
