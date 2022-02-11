﻿using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.States;
using ScheduleService.Domain.Command.Commands.States;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.States;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.States;

public class StateCreateHandlerTest
{
    private static StateCreateHandler MakeSut(
        IStateCreateRepository? StateCreateRepository = null)
    {
        StateCreateRepository ??= new Mock<IStateCreateRepository>().Object;

        return new StateCreateHandler(StateCreateRepository);
    }

    private static StateCreateCommand MakeValidCommand() => new() { CountryId = Guid.NewGuid(), Name = "São Paulo", ExternalCode = "SP123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and AddAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_AddAsync_mustnt_not_be_called()
    {
        StateCreateCommand command = new() { };

        Mock<IStateCreateRepository> StateCreateRepositoryMock = new();

        var sut = MakeSut(StateCreateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        StateCreateRepositoryMock.Verify(x => x.ExistsStateWithName(It.IsAny<string>()), Times.Never);
        StateCreateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(It.IsAny<string>()), Times.Never);
        StateCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<State>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a state with the same externalCode")]
    public void Should_be_invalid_when_already_exists_a_state_with_the_same_externalCode()
    {
        var command = MakeValidCommand();
        Mock<IStateCreateRepository> stateCreateRepositoryMock = new();

        stateCreateRepositoryMock.Setup(x => x.ExistsStateWithExternalCode(command.ExternalCode)).Returns(true);

        var sut = MakeSut(stateCreateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        stateCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<State>()), Times.Never);
        stateCreateRepositoryMock.Verify(x => x.ExistsStateWithName(It.IsAny<string>()), Times.Once);
        stateCreateRepositoryMock.Verify(x => x.ExistsStateWithExternalCode(It.IsAny<string>()), Times.Once);
    }
}
