﻿using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Cities;

public class CityUpdateHandlerTest
{
    private static CityUpdateHandler MakeSut(
        ICityUpdateRepository? cityUpdateRepository = null)
    {
        cityUpdateRepository ??= new Mock<ICityUpdateRepository>().Object;

        return new(cityUpdateRepository);
    }

    private static CityUpdateCommand MakeValidCommand() => new() { Id = Guid.NewGuid(), StateId = Guid.NewGuid(), Name = "São Paulo", ExternalCode = "SP123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and UpdateAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_UpdateAsync_mustnt_not_be_called()
    {
        CityUpdateCommand command = new() { };

        Mock<ICityUpdateRepository> cityUpdateRepositoryMock = new();

        var city = new City(command.Name, command.ExternalCode, command.StateId);
        cityUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(city));

        var sut = MakeSut(cityUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.StateId));

        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithName(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithExternalCode(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.CheckIfStateExists(It.IsAny<Guid>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<City>()), Times.Never);
    }
}
