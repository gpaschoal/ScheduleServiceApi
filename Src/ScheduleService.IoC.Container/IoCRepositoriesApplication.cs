using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Application.Handler.Repositories.Cities;
using ScheduleService.Application.Handler.Repositories.Countries;
using ScheduleService.Application.Handler.Repositories.States;
using ScheduleService.Application.Handler.Repositories.Users;
using ScheduleService.Application.Repository.Repositories.Cities;
using ScheduleService.Application.Repository.Repositories.Countries;
using ScheduleService.Application.Repository.Repositories.States;
using ScheduleService.Application.Repository.Repositories.Users;

namespace ScheduleService.IoC.Container;

internal class IoCRepositoriesApplication
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
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
