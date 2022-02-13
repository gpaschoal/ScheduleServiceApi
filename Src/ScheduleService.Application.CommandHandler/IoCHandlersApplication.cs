using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Application.CommandHandler.Handlers.Cities;
using ScheduleService.Application.CommandHandler.Handlers.Countries;
using ScheduleService.Application.CommandHandler.Handlers.States;
using ScheduleService.Application.CommandHandler.Handlers.Users;
using ScheduleService.Domain.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.CommandHandler.Handlers.States;
using ScheduleService.Domain.CommandHandler.Handlers.Users;

namespace ScheduleService.Application.CommandHandler;

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
