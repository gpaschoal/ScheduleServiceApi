using Microsoft.Extensions.DependencyInjection;
using ScheduleService.Domain.QueryHandler.Handlers.Cities;
using ScheduleService.Domain.QueryHandler.Handlers.Countries;
using ScheduleService.Domain.QueryHandler.Handlers.States;
using ScheduleService.Infrastructure.QueryHandler.Handlers.Cities;
using ScheduleService.Infrastructure.QueryHandler.Handlers.Countries;
using ScheduleService.Infrastructure.QueryHandler.Handlers.States;

namespace ScheduleService.Infrastructure.QueryHandler;

public class IoCQueryHandlers
{
    public static void AddQueryHandlers(IServiceCollection services)
    {
        _ = services
                /* Country */
                .AddScoped<IGetCountryViewModelQueryHandler, GetCountryViewModelQueryHandler>()

                /* State */
                .AddScoped<IGetStateViewModelQueryHandler, GetStateViewModelQueryHandler>()

                /* City */
                .AddScoped<IGetCityViewModelQueryHandler, GetCityViewModelQueryHandler>()
                ;
    }
}
