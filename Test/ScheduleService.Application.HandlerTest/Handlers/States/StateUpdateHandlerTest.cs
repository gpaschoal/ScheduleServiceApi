using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.States;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.States;

public class StateUpdateHandlerTest
{
    private static StateUpdateHandler MakeSut(
        IStateUpdateRepository? stateUpdateRepository = null)
    {
        stateUpdateRepository ??= new Mock<IStateUpdateRepository>().Object;

        return new StateUpdateHandler(stateUpdateRepository);
    }

    private static StateUpdateCommand MakeValidCommand() => new() { Id = Guid.NewGuid(), CountryId = Guid.NewGuid(), Name = "Brazil", ExternalCode = "BR123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and UpdateAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_UpdateAsync_mustnt_not_be_called()
    {
        StateUpdateCommand command = new() { };

        Mock<IStateUpdateRepository> countryUpdateRepositoryMock = new();

        var state = new State(command.Name, command.ExternalCode, command.CountryId);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(state));

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.CountryId));

        countryUpdateRepositoryMock.Verify(x => x.ExistsStateWithName(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.CheckIfCountryExists(It.IsAny<Guid>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<State>()), Times.Never);
    }
}
