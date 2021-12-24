﻿using FluentAssertions;
using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Validator.Validators.Cities;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.ValidatorTest.Validators.Cities;

public class CityCreateValidatorTest
{
    private static CityCreateValidator MakeSut(
       string name = "validName",
       string externalCode = "validCode")
    {
        CityCreateCommand command = new()
        {
            Name = name,
            ExternalCode = externalCode
        };
        CityCreateValidator validator = new();

        validator.SetValue(command);
        validator.Validate();

        return validator;
    }

    [Fact(DisplayName = "Should be valid when command is valid")]
    public void Should_be_valid_when_command_is_valid()
    {
        var validSut = MakeSut();
        validSut.HasErrors.Should().Be(false);
    }

    [Fact(DisplayName = "Should not be valid when name is null")]
    public void Should_not_be_valid_when_name_is_null()
    {
        var invalidSut = MakeSut(name: null);
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Name");
    }

    [Fact(DisplayName = "Should not be valid when externalCode is null")]
    public void Should_not_be_valid_when_externalCode_is_null()
    {
        var invalidSut = MakeSut(externalCode: null);
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("ExternalCode");
    }

    [Fact(DisplayName = "Should not be valid when name exceed max lenght")]
    public void Should_not_be_valid_when_name_exceed_max_lenght()
    {
        var invalidSut = MakeSut(name: "".PadLeft(51, 'x'));
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Name");
    }

    [Fact(DisplayName = "Should not be valid when externalCode exceed max lenght")]
    public void Should_not_be_valid_when_externalCode_exceed_max_lenght()
    {
        var invalidSut = MakeSut(externalCode: "".PadLeft(51, 'x'));
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("ExternalCode");
    }

    [Fact(DisplayName = "Should be valid when name dont exceed max lenght")]
    public void Should_be_valid_when_name_dont_exceed_max_lenght()
    {
        var invalidSut = MakeSut(name: "".PadLeft(49, 'x'));
        invalidSut.HasErrors.Should().Be(false);
    }

    [Fact(DisplayName = "Should be valid when externalCode dont exceed max lenght")]
    public void Should_be_valid_when_externalCode_dont_exceed_max_lenght()
    {
        var invalidSut = MakeSut(externalCode: "".PadLeft(49, 'x'));
        invalidSut.HasErrors.Should().Be(false);
    }
}
