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

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Cities;

public class CityUpdateHandlerTest
{
    private static CityUpdateHandler MakeSut(
        ICityUpdateRepository cityUpdateRepository = null)
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
        cityUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(city);

        var sut = MakeSut(cityUpdateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.StateId));

        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.CheckIfStateExists(It.IsAny<Guid>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<City>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a state with the same name")]
    public void Should_be_invalid_when_already_exists_a_state_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<ICityUpdateRepository> cityUpdateRepositoryMock = new();

        var city = new City(command.Name, command.ExternalCode, command.StateId);
        cityUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(city);
        cityUpdateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(true);
        cityUpdateRepositoryMock.Setup(x => x.ExistsCityWithNameAsync(command.Id, command.Name)).ReturnsAsync(true);

        var sut = MakeSut(cityUpdateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Name));
        cityUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<City>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Id, command.Name), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when already exists an externalCode with the same name")]
    public void Should_be_invalid_when_already_exists_an_externalCode_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<ICityUpdateRepository> cityUpdateRepositoryMock = new();

        var city = new City(command.Name, command.ExternalCode, command.StateId);
        cityUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync((city));
        cityUpdateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(true);
        cityUpdateRepositoryMock.Setup(x => x.ExistsCityWithExternalCodeAsync(command.Id, command.ExternalCode)).ReturnsAsync(true);

        var sut = MakeSut(cityUpdateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        cityUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<City>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Id, command.Name), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when does not exists the state")]
    public void Should_be_invalid_when_does_not_exists_the_countryId()
    {
        var command = MakeValidCommand();
        Mock<ICityUpdateRepository> cityUpdateRepositoryMock = new();

        var city = new City(command.Name, command.ExternalCode, command.StateId);
        cityUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(city);
        cityUpdateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(false);

        var sut = MakeSut(cityUpdateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        cityUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<City>()), Times.Never);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Id, command.Name), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should update a city")]
    public void Should_update_a_city()
    {
        var command = MakeValidCommand();
        Mock<ICityUpdateRepository> cityUpdateRepositoryMock = new();

        var city = new City(command.Name, command.ExternalCode, command.StateId);
        cityUpdateRepositoryMock.Setup(x => x.CheckIfStateExists(command.StateId)).ReturnsAsync(true);
        cityUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(city);

        var sut = MakeSut(cityUpdateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeTrue();
        cityUpdateRepositoryMock.Verify(x => x.UpdateAsync(city), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithNameAsync(command.Id, command.Name), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.ExistsCityWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.CheckIfStateExists(command.StateId), Times.Once);
        cityUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }
}
