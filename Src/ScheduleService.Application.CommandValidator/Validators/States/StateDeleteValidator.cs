using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.States;

namespace ScheduleService.Application.CommandValidator.Validators.States;

public class StateDeleteValidator : AbstractValidator<StateDeleteCommand>
{
    public StateDeleteValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
