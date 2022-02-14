using ScheduleService.Domain.Command.QueryResponses.States;
using ScheduleService.Domain.QueryHandler.Queries.States;

namespace ScheduleService.Domain.QueryHandler.Handlers.States;

public interface IGetStateViewModelQueryHandler : IQueryHandler<GetStateViewModel, StateViewModel?>
{ }
