﻿using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Countries;

namespace ScheduleService.Application.CommandHandler.Validators.Countries;

public class CountryUpdateValidator : AbstractValidator<CountryUpdateCommand>
{
    public CountryUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
        RuleFor(x => x.ExternalCode).NotEmpty().WithMessage(ValidationResource.IsRequired).Length(5, 50).WithMessage(ValidationResource.ShouldHaveMaxLenght);
    }
}