using FluentAssertions;
using ScheduleService.Application.Validator.Validators.Users;
using ScheduleService.Domain.Command.Commands.Users;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.ValidatorTest.Validators.Users;

public class UserSignInCommandTest
{
    private static UserSignInValidator MakeSut(
        string email = "validEmail",
        string password = "validPassword")
    {
        UserSignInCommand command = new() { Email = email, Password = password };
        UserSignInValidator validator = new();

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

    [Fact(DisplayName = "Should not be valid when email is null")]
    public void Should_not_be_valid_when_email_is_null()
    {
        var invalidSut = MakeSut(email: null);
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Email");
    }

    [Fact(DisplayName = "Should not be valid when email is empty")]
    public void Should_not_be_valid_when_email_is_empty()
    {
        var invalidSut = MakeSut(email: "");
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Email");
    }

    [Fact(DisplayName = "Should not be valid when email is white space")]
    public void Should_not_be_valid_when_email_is_white_space()
    {
        var invalidSut = MakeSut(email: "         ");
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Email");
    }

    [Fact(DisplayName = "Should not be valid when password is null")]
    public void Should_not_be_valid_when_password_is_null()
    {
        var invalidSut = MakeSut(password: null);
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Password");
    }

    [Fact(DisplayName = "Should not be valid when password is empty")]
    public void Should_not_be_valid_when_password_is_empty()
    {
        var invalidSut = MakeSut(password: "");
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Password");
    }

    [Fact(DisplayName = "Should not be valid when Password is white space")]
    public void Should_not_be_valid_when_password_is_white_space()
    {
        var invalidSut = MakeSut(password: "         ");
        invalidSut.HasErrors.Should().Be(true);
        invalidSut.ResultData.FieldErrors.Single().Key.Should().Be("Password");
    }
}
