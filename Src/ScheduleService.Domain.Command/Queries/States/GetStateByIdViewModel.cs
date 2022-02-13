using ScheduleService.Domain.Command.QueryResponses.States;

namespace ScheduleService.Domain.Command.Queries.States;

public class GetStateByIdViewModel : IGetById<StateViewModel>
{
    public Guid Id { get; set; }
}
