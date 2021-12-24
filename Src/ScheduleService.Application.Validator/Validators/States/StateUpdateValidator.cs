using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.States;

namespace ScheduleService.Application.Validator.Validators.States;

public class StateUpdateValidator : Validation<StateUpdateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id).IsRequired();
        ForMember(x => x.Name).IsRequired().HasLenght(50);
        ForMember(x => x.ExternalCode).IsRequired().HasLenght(50);
    }
}
