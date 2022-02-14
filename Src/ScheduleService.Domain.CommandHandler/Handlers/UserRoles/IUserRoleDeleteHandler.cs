﻿using ScheduleService.Application.Shared;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Domain.CommandHandler.Handlers.UserRoles;

public interface IUserRoleDeleteHandler : ICommandHandler<UserRoleDeleteCommand, CustomResultData>
{ }
