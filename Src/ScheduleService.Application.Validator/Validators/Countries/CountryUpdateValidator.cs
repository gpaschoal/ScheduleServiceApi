using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.Countries;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Validator.Validators.Countries;

public class CountryUpdateValidator : Validation<CountryUpdateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id)
            .IsRequired(ValidationResource.IsRequired);
        ForMember(x => x.Name)
            .IsRequired(ValidationResource.IsRequired)
            .HasLenght(50, ValidationResource.ShouldHaveMaxLenght);
        ForMember(x => x.ExternalCode)
            .IsRequired(ValidationResource.IsRequired)
            .HasLenght(50, ValidationResource.ShouldHaveMaxLenght);
    }
}
