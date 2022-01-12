using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Countries;

namespace ScheduleService.Application.Validator.Validators.Countries;

public class CountryCreateValidator : Validation<CountryCreateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Name)
            .IsRequired(ValidationResource.IsRequired)
            .IsNotNullOrWhiteSpace(ValidationResource.IsRequired)
            .HasMaxLenght(50, ValidationResource.ShouldHaveMaxLenght);
        ForMember(x => x.ExternalCode)
            .IsRequired(ValidationResource.IsRequired)
            .IsNotNullOrWhiteSpace(ValidationResource.IsRequired)
            .HasMaxLenght(50, ValidationResource.ShouldHaveMaxLenght);
    }
}
