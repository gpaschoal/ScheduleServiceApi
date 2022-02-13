using ScheduleService.Domain.Command.QueryResponses.States;

namespace ScheduleService.Domain.Command.Queries.States;

public class GetStateViewModel : IGetById<StateViewModel>
{
    public Guid Id { get; set; }
}
