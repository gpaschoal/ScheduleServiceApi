using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Handler.Repositories.States;
using System;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.States;

public class StateDeleteHandlerTest
{
    private static StateDeleteHandler MakeSut(
        IStateDeleteRepository? stateDeleteRepository = null)
    {
        stateDeleteRepository ??= new Mock<IStateDeleteRepository>().Object;

        return new(stateDeleteRepository);
    }

    private static StateDeleteCommand MakeValidCommand() => new() { Id = Guid.NewGuid() };

    [Fact(DisplayName = "Should be invalid when command is invalid and DeleteAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_DeleteAsync_mustnt_not_be_called()
    {
        StateDeleteCommand command = new() { };

        Mock<IStateDeleteRepository> StateDeleteRepositoryMock = new();

        var sut = MakeSut(StateDeleteRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));

        StateDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(It.IsAny<Guid>()), Times.Never);
        StateDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByCity(It.IsAny<Guid>()), Times.Never);
        StateDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }
}
