using FluentAssertions;
using ScheduleService.Application.Command.Commands.Cities;
using ScheduleService.Application.Validator.Validators.Cities;
using System;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.ValidatorTest.Validators.Cities;

public class CityDeleteValidatorTest
{
    private static CityDeleteValidator MakeSut(Guid? id = null)
    {
        CityDeleteCommand command = new() { Id = id ?? Guid.NewGuid() };
        CityDeleteValidator validator = new();

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

    [Fact(DisplayName = "Should not be valid when id is empty")]
    public void Should_not_be_valid_when_id_is_empty()
    {
        var invalidSut = MakeSut(id: Guid.Empty);
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Id");
    }
}
