using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Validator.Validators.States;

public class StateDeleteValidator : Validation<StateDeleteCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id)
            .IsRequired(ValidationResource.IsRequired);
    }
}
