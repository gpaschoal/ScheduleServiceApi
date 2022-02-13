using Microsoft.EntityFrameworkCore;
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

    public async ValueTask<CityViewModel?> HandleAsync(GetCityViewModel query)
    {
        var result = await Queryable
            .Where(x => x.Id.Equals(query.Id))
            .Include(x => x.State)
            .ThenInclude(x => x.Country)
            .Select(x => new CityViewModel
            {
                Id = x.Id,
                Name = x.Name.Trim(),
                ExternalCode = x.ExternalCode.Trim(),
                StateId = x.StateId,
                StateName = x.State.Name.Trim(),
                StateExternalCode = x.State.ExternalCode.Trim(),
                CountryId = x.State.CountryId,
                CountryName = x.State.Country.Name.Trim(),
                CountryExternalCode = x.State.Country.ExternalCode.Trim(),
            })
            .FirstOrDefaultAsync();

        return result;
    }
}
