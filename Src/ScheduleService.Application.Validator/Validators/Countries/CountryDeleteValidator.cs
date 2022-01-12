using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Countries;

namespace ScheduleService.Application.Validator.Validators.Countries;

public class CountryDeleteValidator : Validation<CountryDeleteCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id)
            .IsNotEmpty(ValidationResource.IsRequired);
    }
}
