using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.CommandHandler.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using ScheduleService.Domain.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.Cities;

public class CityCreateHandlerTest
{
    private static CityCreateHandler MakeSut(
        ICityCreateRepository cityCreateRepository = null)
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

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(It.IsAny<string>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(It.IsAny<string>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a city with the same name")]
    public void Should_be_invalid_when_already_exists_a_city_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<ICityCreateRepository> cityCreateRepositoryMock = new();

        cityCreateRepositoryMock.Setup(x => x.ExistsCityWithNameAsync(command.Name)).ReturnsAsync(true);
        cityCreateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(true);

        var sut = MakeSut(cityCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Name));
        cityCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Name), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.ExternalCode), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when already exists a city with the same externalCode")]
    public void Should_be_invalid_when_already_exists_a_city_with_the_same_externalCode()
    {
        var command = MakeValidCommand();
        Mock<ICityCreateRepository> cityCreateRepositoryMock = new();
        cityCreateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(true);

        cityCreateRepositoryMock.Setup(x => x.ExistsCityWithExternalCodeAsync(command.ExternalCode)).ReturnsAsync(true);

        var sut = MakeSut(cityCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        cityCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Name), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.ExternalCode), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when does not exists the state")]
    public void Should_be_invalid_when_does_not_exists_the_state()
    {
        var command = MakeValidCommand();
        Mock<ICityCreateRepository> cityCreateRepositoryMock = new();
        cityCreateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(false);

        var sut = MakeSut(cityCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        cityCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Never);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Name), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.ExternalCode), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
    }

    [Fact(DisplayName = "Should add a city")]
    public void Should_add_a_city()
    {
        var command = MakeValidCommand();
        Mock<ICityCreateRepository> cityCreateRepositoryMock = new();
        cityCreateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(true);

        var sut = MakeSut(cityCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeTrue();
        resultData.Errors.Should().BeEmpty();
        cityCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<City>()), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Name), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.ExternalCode), Times.Once);
        cityCreateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
    }
}
