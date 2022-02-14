﻿using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.UserRoles;

namespace ScheduleService.Application.CommandHandler.Validators.UserRoles;

public class UserRoleUpdateValidator : AbstractValidator<UserRoleUpdateCommand>
{
}
