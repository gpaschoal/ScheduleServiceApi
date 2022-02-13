using ScheduleService.Domain.Command.Queries.States;
using ScheduleService.Domain.Command.QueryResponses.States;

namespace ScheduleService.Domain.QueryHandler.Handlers.States;

public interface IGetStateViewModelQuery : IQueryHandler<GetStateViewModel, StateViewModel>
{ }
