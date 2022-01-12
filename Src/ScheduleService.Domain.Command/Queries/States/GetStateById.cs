namespace ScheduleService.Domain.Command.Queries.States;

public class GetStateById : IGetById
{
    public Guid Id { get; set; }
}
