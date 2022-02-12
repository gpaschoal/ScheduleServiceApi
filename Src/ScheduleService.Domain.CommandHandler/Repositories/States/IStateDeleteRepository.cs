using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.CommandHandler.Repositories.States;

public interface IStateDeleteRepository : IDeleteRepository<State>
{
    ValueTask<bool> CheckIfIsUsedByCity(Guid id);
}
