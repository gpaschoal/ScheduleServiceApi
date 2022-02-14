using FluentValidation;
using ScheduleService.Domain.CommandHandler.Commands.RolePolicies;

namespace ScheduleService.Application.CommandHandler.Validators.RolePolicies;

public class RolePolicyDeleteValidator : AbstractValidator<RolePolicyDeleteCommand>
{
}
