using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Validator.Validators.Cities;

public class CityDeleteValidator : Validation<CityDeleteCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id)
            .IsNotEmpty(ValidationResource.IsRequired);
    }
}
