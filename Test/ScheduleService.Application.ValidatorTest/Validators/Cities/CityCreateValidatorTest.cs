using FluentAssertions;
using FluentValidation.Results;
using ScheduleService.Application.CommandValidator.Validators.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.CommandValidatorTest.Validators.Cities;

public class CityCreateValidatorTest
{
    private static ValidationResult MakeSut(
       string name = "validName",
       string externalCode = "validCode")
    {
        CityCreateCommand command = new()
        {
            Name = name,
            ExternalCode = externalCode
        };
        CityCreateValidator validator = new();

        return validator.Validate(command);
    }

    [Fact(DisplayName = "Should be valid when command is valid")]
    public void Should_be_valid_when_command_is_valid()
    {
        var validSut = MakeSut();
        validSut.IsValid.Should().Be(true);
    }

    [Fact(DisplayName = "Should not be valid when name is null")]
    public void Should_not_be_valid_when_name_is_null()
    {
        var invalidSut = MakeSut(name: null);
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Name");
    }

    [Fact(DisplayName = "Should not be valid when externalCode is null")]
    public void Should_not_be_valid_when_externalCode_is_null()
    {
        var invalidSut = MakeSut(externalCode: null);
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("ExternalCode");
    }

    [Fact(DisplayName = "Should not be valid when name exceed max lenght")]
    public void Should_not_be_valid_when_name_exceed_max_lenght()
    {
        var invalidSut = MakeSut(name: "".PadLeft(51, 'x'));
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Name");
    }

    [Fact(DisplayName = "Should not be valid when externalCode exceed max lenght")]
    public void Should_not_be_valid_when_externalCode_exceed_max_lenght()
    {
        var invalidSut = MakeSut(externalCode: "".PadLeft(51, 'x'));
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("ExternalCode");
    }

    [Fact(DisplayName = "Should be valid when name dont exceed max lenght")]
    public void Should_be_valid_when_name_dont_exceed_max_lenght()
    {
        var invalidSut = MakeSut(name: "".PadLeft(49, 'x'));
        invalidSut.IsValid.Should().Be(true);
    }

    [Fact(DisplayName = "Should be valid when externalCode dont exceed max lenght")]
    public void Should_be_valid_when_externalCode_dont_exceed_max_lenght()
    {
        var invalidSut = MakeSut(externalCode: "".PadLeft(49, 'x'));
        invalidSut.IsValid.Should().Be(true);
    }

    [Fact(DisplayName = "Should not be valid when name is empty")]
    public void Should_not_be_valid_when_name_is_empty()
    {
        var invalidSut = MakeSut(name: "");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Select(x => x.PropertyName).Distinct().Single().Should().Be("Name");
    }

    [Fact(DisplayName = "Should not be valid when externalCode is empty")]
    public void Should_not_be_valid_when_externalCode_is_empty()
    {
        var invalidSut = MakeSut(externalCode: "");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Select(x => x.PropertyName).Distinct().Single().Should().Be("ExternalCode");
    }

    [Fact(DisplayName = "Should not be valid when name is only white space")]
    public void Should_not_be_valid_when_name_is_only_white_space()
    {
        var invalidSut = MakeSut(name: "                  ");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Name");
    }

    [Fact(DisplayName = "Should not be valid when externalCode is only white space")]
    public void Should_not_be_valid_when_externalCode_is_only_white_space()
    {
        var invalidSut = MakeSut(externalCode: "                 ");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("ExternalCode");
    }
}
