using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Command.QueryResponses.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.QueryHandler.Handlers.States;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.QueryHandler.Handlers.States;

internal class GetStateViewModelQueryHandler : QueryHandlerBase<State>, IGetStateViewModelQueryHandler
{
    public GetStateViewModelQueryHandler(AppDbContext context) : base(context)
    { }

    public async ValueTask<StateViewModel> HandleAsync(Domain.Command.Queries.States.GetStateViewModel query)
    {
        var result = await Queryable
            .Where(x => x.Id.Equals(query.Id))
            .Include(x => x.Country)
            .Select(x => new StateViewModel
            {
                Id = x.Id,
                Name = x.Name.Trim(),
                ExternalCode = x.ExternalCode.Trim(),
                CountryId = x.CountryId,
                CountryName = x.Country.Name.Trim(),
                CountryExternalCode = x.Country.ExternalCode.Trim(),
            })
            .FirstOrDefaultAsync();

        return result;
    }
}
