using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Command.Queries.Countries;
using ScheduleService.Domain.Command.QueryResponses.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.QueryHandler.Handlers.Countries;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.QueryHandler.Handlers.Countries;

internal class GetCountryViewModelQueryHandler : QueryHandlerBase<Country>, IGetCountryViewModelQueryHandler
{
    public GetCountryViewModelQueryHandler(AppDbContext context) : base(context)
    { }

    public async ValueTask<CountryViewModel> HandleAsync(GetCountryViewModel query)
    {
        var result = await Queryable
            .Where(x => x.Id.Equals(query.Id))
            .Select(x => new CountryViewModel
            {
                Id = x.Id,
                Name = x.Name.Trim(),
                ExternalCode = x.ExternalCode.Trim()
            })
            .FirstOrDefaultAsync();

        return result;
    }
}
