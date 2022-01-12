﻿using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Domain.Handler.Handlers.Cities;

public interface ICityCreateHandler : IRequestHandler<CityCreateCommand, CustomResultData<Guid>>
{ }
