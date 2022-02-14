using FluentAssertions;
using FluentValidation.Results;
using ScheduleService.Application.CommandValidator.Validators.Cities;
using ScheduleService.Domain.CommandHandler.Commands.Cities;
using System;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.CommandValidatorTest.Validators.Cities;

public class CityDeleteValidatorTest
{
    private static ValidationResult MakeSut(Guid? id = null)
    {
        CityDeleteCommand command = new() { Id = id ?? Guid.NewGuid() };
        CityDeleteValidator validator = new();

        return validator.Validate(command);
    }

    [Fact(DisplayName = "Should be valid when command is valid")]
    public void Should_be_valid_when_command_is_valid()
    {
        var validSut = MakeSut();
        validSut.IsValid.Should().Be(true);
    }

    [Fact(DisplayName = "Should not be valid when id is empty")]
    public void Should_not_be_valid_when_id_is_empty()
    {
        var invalidSut = MakeSut(id: Guid.Empty);
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Id");
    }
}
