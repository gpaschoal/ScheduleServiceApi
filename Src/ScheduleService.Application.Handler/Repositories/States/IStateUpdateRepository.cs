﻿using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Repositories.States;

public interface IStateUpdateRepository : IUpdateRepository<State>
{
    bool ExistsStateWithName(Guid id, string name);
    bool ExistsStateWithExternalCode(Guid id, string externalCode);
}
