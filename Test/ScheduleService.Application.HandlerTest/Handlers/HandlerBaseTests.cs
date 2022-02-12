using FluentAssertions;
using Moq;
using ScheduleService.Application.Shared;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers;

public partial class HandlerBaseTests
{
    private static HandlerBaseStub MakeSut() => new();


    [Fact(DisplayName = "HandlerBase should be valid when is created")]
    public void HandlerBase_should_be_valid_when_is_created_and_invalid_after_add_an_error()
    {
        var sut = MakeSut();

        sut.IsInvalid.Should().BeFalse();
        sut.ValidResponseAsync().Result.IsValid.Should().BeTrue();
        sut.InvalidResponseAsync().Result.IsValid.Should().BeTrue();
        sut.ValidResponse().IsValid.Should().BeTrue();
        sut.InvalidResponse().IsValid.Should().BeTrue();
        sut.IsInvalid.Should().BeFalse();

        string key = "_key";
        sut.AddError(key, "this key is invalid");

        sut.IsInvalid.Should().BeTrue();
        sut.ValidResponseAsync().Result.IsValid.Should().BeTrue();
        sut.IsInvalid.Should().BeTrue();
        sut.InvalidResponseAsync().Result.IsValid.Should().BeFalse();
        sut.ValidResponse().IsValid.Should().BeTrue();
        sut.InvalidResponse().IsValid.Should().BeFalse();
        sut.HandleExecutionCalls.Should().Be(0);
    }

    [Fact(DisplayName = "Handle should execute HandleExecution when command is Valid")]
    public void Handle_should_execute_HandleExecution_when_command_is_Valid()
    {
        CustomResultData invalidDataResult = new();
        invalidDataResult.IsValid.Should().BeTrue();

        var sut = MakeSut();

        CustomResultData commandResult = sut.Handle(It.IsAny<StubCommand>(), System.Threading.CancellationToken.None).Result;

        commandResult.IsValid.Should().BeTrue();
        sut.HandleExecutionCalls.Should().Be(1);
    }

    [Fact(DisplayName = "AddError should add errors to the intern Response")]
    public void AddError_should_add_errors_to_the_intern_Response()
    {
        var sut = MakeSut();

        sut.IsInvalid.Should().BeFalse();

        string key = "_key";
        sut.AddError(key, "this key is invalid");

        sut.IsInvalid.Should().BeTrue();

        var invalidCommandResult = sut.InvalidResponseAsync().Result;
        invalidCommandResult.IsValid.Should().BeFalse();

        invalidCommandResult.Errors.Single().Key.Should().Be(key);
    }

    [Fact(DisplayName = "AddError should add message errors to the intern Response")]
    public void AddError_should_add_message_errors_to_the_intern_Response()
    {
        var sut = MakeSut();

        sut.IsInvalid.Should().BeFalse();

        string message = "this message is invalid";
        sut.AddError(message);

        sut.IsInvalid.Should().BeTrue();

        var invalidCommandResult = sut.InvalidResponseAsync().Result;
        invalidCommandResult.IsValid.Should().BeFalse();

        invalidCommandResult.Errors.SelectMany(x => x.Value).Single().Should().Be(message);
    }
}
