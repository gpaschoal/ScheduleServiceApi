using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Validator.Validators.Cities;

public class CityCreateValidator : Validation<CityCreateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Name)
            .IsRequired(ValidationResource.IsRequired)
            .HasLenght(50, ValidationResource.ShouldHaveMaxLenght);
        ForMember(x => x.ExternalCode)
            .IsRequired(ValidationResource.IsRequired)
            .HasLenght(50, ValidationResource.ShouldHaveMaxLenght);
    }
}
