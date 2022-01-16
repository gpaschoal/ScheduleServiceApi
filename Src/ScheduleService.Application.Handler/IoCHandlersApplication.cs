using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Application.Handler.Handlers.Cities;
using ScheduleService.Application.Handler.Handlers.Countries;
using ScheduleService.Application.Handler.Handlers.States;
using ScheduleService.Application.Handler.Handlers.Users;
using ScheduleService.Domain.Handler.Handlers.Cities;
using ScheduleService.Domain.Handler.Handlers.Countries;
using ScheduleService.Domain.Handler.Handlers.States;
using ScheduleService.Domain.Handler.Handlers.Users;

namespace ScheduleService.Application.Handler;

public static class IoCHandlersApplication
{
    public static void AddApplicationHandler(IServiceCollection services)
    {
        _ = services
                /* City */
                .AddScoped<ICityCreateHandler, CityCreateHandler>()
                .AddScoped<ICityUpdateHandler, CityUpdateHandler>()
                .AddScoped<ICityDeleteHandler, CityDeleteHandler>()

                /* State */
                .AddScoped<IStateCreateHandler, StateCreateHandler>()
                .AddScoped<IStateUpdateHandler, StateUpdateHandler>()
                .AddScoped<IStateDeleteHandler, StateDeleteHandler>()

                /* Country */
                .AddScoped<ICountryCreateHandler, CountryCreateHandler>()
                .AddScoped<ICountryUpdateHandler, CountryUpdateHandler>()
                .AddScoped<ICountryDeleteHandler, CountryDeleteHandler>()

                /* User */
                .AddScoped<IUserSignInHandler, UserSignInHandler>()
                ;
    }
}
