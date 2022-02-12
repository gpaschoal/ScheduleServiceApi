using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.CommandHandler.Repositories.States;
using ScheduleService.Domain.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.States;

public class StateUpdateHandlerTest
{
    private static StateUpdateHandler MakeSut(
        IStateUpdateRepository? stateUpdateRepository = null)
    {
        stateUpdateRepository ??= new Mock<IStateUpdateRepository>().Object;

        return new(stateUpdateRepository);
    }

    private static StateUpdateCommand MakeValidCommand() => new() { Id = Guid.NewGuid(), CountryId = Guid.NewGuid(), Name = "São Paulo", ExternalCode = "SP123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and UpdateAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_UpdateAsync_mustnt_not_be_called()
    {
        StateUpdateCommand command = new() { };

        Mock<IStateUpdateRepository> stateUpdateRepositoryMock = new();

        var state = new State(command.Name, command.ExternalCode, command.CountryId);
        stateUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(state));

        var sut = MakeSut(stateUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.CountryId));

        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithName(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.CheckIfCountryExists(It.IsAny<Guid>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<State>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a state with the same name")]
    public void Should_be_invalid_when_already_exists_a_state_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<IStateUpdateRepository> stateUpdateRepositoryMock = new();

        var state = new State(command.Name, command.ExternalCode, command.CountryId);
        stateUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(state));
        stateUpdateRepositoryMock.Setup(x => x.CheckIfCountryExists(command.CountryId)).Returns(ValueTask.FromResult(true));
        stateUpdateRepositoryMock.Setup(x => x.ExistsStateWithName(command.Id, command.Name)).Returns(true);

        var sut = MakeSut(stateUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Name));
        stateUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<State>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithName(command.Id, command.Name), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(command.Id, command.ExternalCode), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.CheckIfCountryExists(command.CountryId), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when already exists an externalCode with the same name")]
    public void Should_be_invalid_when_already_exists_an_externalCode_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<IStateUpdateRepository> stateUpdateRepositoryMock = new();

        var state = new State(command.Name, command.ExternalCode, command.CountryId);
        stateUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(state));
        stateUpdateRepositoryMock.Setup(x => x.CheckIfCountryExists(command.CountryId)).Returns(ValueTask.FromResult(true));
        stateUpdateRepositoryMock.Setup(x => x.ExistsStateWithExternalCode(command.Id, command.ExternalCode)).Returns(true);

        var sut = MakeSut(stateUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        stateUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<State>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithName(command.Id, command.Name), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(command.Id, command.ExternalCode), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.CheckIfCountryExists(command.CountryId), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when does not exists the countryId")]
    public void Should_be_invalid_when_does_not_exists_the_countryId()
    {
        var command = MakeValidCommand();
        Mock<IStateUpdateRepository> stateUpdateRepositoryMock = new();

        var state = new State(command.Name, command.ExternalCode, command.CountryId);
        stateUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(state));
        stateUpdateRepositoryMock.Setup(x => x.CheckIfCountryExists(command.CountryId)).Returns(ValueTask.FromResult(false));

        var sut = MakeSut(stateUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        stateUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<State>()), Times.Never);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithName(command.Id, command.Name), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(command.Id, command.ExternalCode), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.CheckIfCountryExists(command.CountryId), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should update a state")]
    public void Should_update_a_state()
    {
        var command = MakeValidCommand();
        Mock<IStateUpdateRepository> stateUpdateRepositoryMock = new();

        var state = new State(command.Name, command.ExternalCode, command.CountryId);
        stateUpdateRepositoryMock.Setup(x => x.CheckIfCountryExists(command.CountryId)).Returns(ValueTask.FromResult(true));
        stateUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(state));

        var sut = MakeSut(stateUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeTrue();
        stateUpdateRepositoryMock.Verify(x => x.UpdateAsync(state), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithName(command.Id, command.Name), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(command.Id, command.ExternalCode), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.CheckIfCountryExists(command.CountryId), Times.Once);
        stateUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }
}
