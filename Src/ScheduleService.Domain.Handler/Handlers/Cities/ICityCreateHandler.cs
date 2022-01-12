﻿using ScheduleService.Application.Shared;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.Handler.Handlers;

namespace ScheduleService.Application.Handler.Handlers.Cities;

public interface ICityCreateHandler : IRequestHandler<CityCreateCommand, CustomResultData<Guid>>
{ }
