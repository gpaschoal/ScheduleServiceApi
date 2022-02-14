﻿using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

namespace ScheduleService.Application.CommandValidator.Validators.RolePolicies;

public class RolePolicyUpdateValidator : AbstractValidator<RolePolicyUpdateCommand>
{
}
