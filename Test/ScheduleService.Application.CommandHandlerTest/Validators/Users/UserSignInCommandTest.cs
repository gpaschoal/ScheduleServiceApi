﻿using FluentAssertions;
using FluentValidation.Results;
using ScheduleService.Application.CommandHandler.Validators.Users;
using ScheduleService.Domain.CommandHandler.Commands.Users;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Validators.Users;

public class UserSignInCommandTest
{
    private static ValidationResult MakeSut(
        string email = "validEmail",
        string password = "validPassword")
    {
        UserSignInCommand command = new() { Email = email, Password = password };
        UserSignInValidator validator = new();

        return validator.Validate(command);
    }

    [Fact(DisplayName = "Should be valid when command is valid")]
    public void Should_be_valid_when_command_is_valid()
    {
        var validSut = MakeSut();
        validSut.IsValid.Should().Be(true);
    }

    [Fact(DisplayName = "Should not be valid when email is null")]
    public void Should_not_be_valid_when_email_is_null()
    {
        var invalidSut = MakeSut(email: null);
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Email");
    }

    [Fact(DisplayName = "Should not be valid when email is empty")]
    public void Should_not_be_valid_when_email_is_empty()
    {
        var invalidSut = MakeSut(email: "");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Email");
    }

    [Fact(DisplayName = "Should not be valid when email is white space")]
    public void Should_not_be_valid_when_email_is_white_space()
    {
        var invalidSut = MakeSut(email: "         ");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Email");
    }

    [Fact(DisplayName = "Should not be valid when password is null")]
    public void Should_not_be_valid_when_password_is_null()
    {
        var invalidSut = MakeSut(password: null);
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Password");
    }

    [Fact(DisplayName = "Should not be valid when password is empty")]
    public void Should_not_be_valid_when_password_is_empty()
    {
        var invalidSut = MakeSut(password: "");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Password");
    }

    [Fact(DisplayName = "Should not be valid when Password is white space")]
    public void Should_not_be_valid_when_password_is_white_space()
    {
        var invalidSut = MakeSut(password: "         ");
        invalidSut.IsValid.Should().Be(false);
        invalidSut.Errors.Single().PropertyName.Should().Be("Password");
    }
}
