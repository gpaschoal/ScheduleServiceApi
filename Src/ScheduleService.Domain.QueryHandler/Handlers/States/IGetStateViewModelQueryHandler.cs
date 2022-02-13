using ScheduleService.Domain.Command.Queries.States;
using ScheduleService.Domain.Command.QueryResponses.States;

namespace ScheduleService.Domain.QueryHandler.Handlers.States;

public interface IGetStateViewModelQueryHandler : IQueryHandler<GetStateViewModel, StateViewModel>
{ }
