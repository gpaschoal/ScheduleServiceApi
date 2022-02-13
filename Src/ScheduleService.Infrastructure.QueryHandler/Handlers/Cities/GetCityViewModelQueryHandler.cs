using ScheduleService.Domain.Command.Queries.Cities;
using ScheduleService.Domain.Command.QueryResponses.Cities;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.QueryHandler.Handlers.Cities;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.QueryHandler.Handlers.Cities;

internal class GetCityViewModelQueryHandler : QueryHandlerBase<City>, IGetCityViewModelQueryHandler
{
    public GetCityViewModelQueryHandler(AppDbContext context) : base(context)
    { }

    public ValueTask<CityViewModel> HandleAsync(GetCityViewModel query)
    {
        throw new NotImplementedException();
    }
}
