﻿using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.Roles;

namespace ScheduleService.Application.CommandHandler.Validators.Roles;

public class RoleCreateValidator : AbstractValidator<RoleCreateCommand>
{
}
