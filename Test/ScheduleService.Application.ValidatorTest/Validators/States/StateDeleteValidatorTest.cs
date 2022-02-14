using FluentAssertions;
using FluentValidation.Results;
using ScheduleService.Application.CommandValidator.Validators.States;
using ScheduleService.Domain.CommandHandler.Commands.States;
using System;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.CommandValidatorTest.Validators.States;

public class StateDeleteValidatorTest
{
    private static ValidationResult MakeSut(
        Guid? id = null)
    {
        StateDeleteCommand command = new() { Id = id ?? Guid.NewGuid() };
        StateDeleteValidator validator = new();

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
