using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.States;

namespace ScheduleService.Application.CommandValidator.Validators.States;

public class StateDeleteValidator : AbstractValidator<StateDeleteCommand>
{
    public StateDeleteValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
