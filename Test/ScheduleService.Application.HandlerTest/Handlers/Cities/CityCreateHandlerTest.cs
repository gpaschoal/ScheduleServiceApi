using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using System;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.Cities;

public class CityCreateHandlerTest
{
    private static CityCreateHandler MakeSut(
        ICityCreateRepository? cityCreateRepository = null)
    {
        cityCreateRepository ??= new Mock<ICityCreateRepository>().Object;

        return new(cityCreateRepository);
    }

    private static CityCreateCommand MakeValidCommand() => new() { StateId = Guid.NewGuid(), Name = "São Paulo", ExternalCode = "SP123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and AddAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_AddAsync_mustnt_not_be_called()
    {
        CityCreateCommand command = new() { };

        Mock<ICityCreateRepository> cityCreateRepositoryMock = new();

        var sut = MakeSut(cityCreateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithName(It.IsAny<string>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithExternalCode(It.IsAny<string>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Never);
    }
}
