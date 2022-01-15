using FluentAssertions;
using FluentValidation.Results;
using ScheduleService.Application.Validator.Validators.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using System;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.ValidatorTest.Validators.Countries;

public class CountryDeleteValidatorTest
{
    private static ValidationResult MakeSut(
        Guid? id = null)
    {
        CountryDeleteCommand command = new() { Id = id ?? Guid.NewGuid() };
        CountryDeleteValidator validator = new();

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
