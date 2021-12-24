﻿using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Shared.Resources;

namespace ScheduleService.Application.Validator.Validators.States;

public class StateUpdateValidator : Validation<StateUpdateCommand>
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