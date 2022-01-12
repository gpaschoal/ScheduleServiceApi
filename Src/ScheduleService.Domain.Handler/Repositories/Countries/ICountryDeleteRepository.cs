using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Domain.Handler.Repositories.Countries;

public interface ICountryDeleteRepository : IDeleteRepository<Country>
{
    ValueTask<bool> CheckIfIsUsedByState(Guid id);
}
