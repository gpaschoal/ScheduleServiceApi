using ScheduleService.Domain.Command.QueryResponses.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.QueryHandler.Handlers.States;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.QueryHandler.Handlers.States;

internal class GetStateViewModelQueryHandler : QueryHandlerBase<State>, IGetStateViewModelQuery
{
    public GetStateViewModelQueryHandler(AppDbContext context) : base(context)
    { }

    public ValueTask<StateViewModel> HandleAsync(Domain.Command.Queries.States.GetStateViewModel query)
    {
        throw new NotImplementedException();
    }
}
