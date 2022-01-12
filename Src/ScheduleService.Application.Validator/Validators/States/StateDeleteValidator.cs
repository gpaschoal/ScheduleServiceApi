using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.States;

namespace ScheduleService.Application.Validator.Validators.States;

public class StateDeleteValidator : Validation<StateDeleteCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id)
            .IsNotEmpty(ValidationResource.IsRequired);
    }
}
