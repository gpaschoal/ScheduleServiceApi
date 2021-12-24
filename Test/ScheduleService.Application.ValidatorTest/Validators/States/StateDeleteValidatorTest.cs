using FluentAssertions;
using ScheduleService.Application.Command.Commands.States;
using ScheduleService.Application.Validator.Validators.States;
using System;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.ValidatorTest.Validators.States;

public class StateDeleteValidatorTest
{
    private static StateDeleteValidator MakeSut(Guid? id = null)
    {
        StateDeleteCommand command = new() { Id = id ?? Guid.NewGuid() };
        StateDeleteValidator validator = new();

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
