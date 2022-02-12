using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Handler.Repositories.States;
using System;
using System.Threading;
using System.Threading.Tasks;
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

        Mock<IStateDeleteRepository> stateDeleteRepositoryMock = new();

        var sut = MakeSut(stateDeleteRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));

        stateDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(It.IsAny<Guid>()), Times.Never);
        stateDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByCity(It.IsAny<Guid>()), Times.Never);
        stateDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }

    [Fact(DisplayName = "Should not delete when State does not exist in the DB")]
    public void Should_not_delete_when_State_does_not_exist_in_the_DB()
    {
        StateDeleteCommand command = MakeValidCommand();

        Mock<IStateDeleteRepository> stateDeleteRepositoryMock = new();

        stateDeleteRepositoryMock.Setup(x => x.CheckIfExistByIdAsync(command.Id)).Returns(ValueTask.FromResult(false));

        var sut = MakeSut(stateDeleteRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        stateDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(command.Id), Times.Once);
        stateDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByCity(command.Id), Times.Once);
        stateDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }
}
