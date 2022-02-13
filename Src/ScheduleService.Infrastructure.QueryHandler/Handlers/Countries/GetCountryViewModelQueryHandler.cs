using ScheduleService.Domain.Command.QueryResponses.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.QueryHandler.Handlers.Countries;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.QueryHandler.Handlers.Countries;

internal class GetCountryViewModelQueryHandler : QueryHandlerBase<Country>, IGetCountryViewModelQuery
{
    public GetCountryViewModelQueryHandler(AppDbContext context) : base(context)
    { }

    public ValueTask<CountryViewModel> HandleAsync(Domain.Command.Queries.Countries.GetCountryViewModel query)
    {
        throw new NotImplementedException();
    }
}
