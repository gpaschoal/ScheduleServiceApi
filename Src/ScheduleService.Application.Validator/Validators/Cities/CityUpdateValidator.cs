﻿using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Cities;

namespace ScheduleService.Application.Validator.Validators.Cities;

public class CityUpdateValidator : Validation<CityUpdateCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Id)
            .IsNotEmpty(ValidationResource.IsRequired);
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
