using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.CommandHandler.Repositories.Countries;
using ScheduleService.Domain.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Countries;

public class CountryUpdateHandlerTest
{
    private static CountryUpdateHandler MakeSut(
        ICountryUpdateRepository? countryUpdateRepository = null)
    {
        countryUpdateRepository ??= new Mock<ICountryUpdateRepository>().Object;

        return new(countryUpdateRepository);
    }

    private static CountryUpdateCommand MakeValidCommand() => new() { Id = Guid.NewGuid(), Name = "Brazil", ExternalCode = "BR123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and UpdateAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_UpdateAsync_mustnt_not_be_called()
    {
        CountryUpdateCommand command = new() { };

        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var country = new Country(command.Name, command.ExternalCode);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(country));

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithNameAsync(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a country with the same name")]
    public void Should_be_invalid_when_already_exists_a_country_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var country = new Country(command.Name, command.ExternalCode);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(country));
        countryUpdateRepositoryMock.Setup(x => x.ExistsCountryWithNameAsync(command.Id, command.Name)).Returns(ValueTask.FromResult(true));

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Name));
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithNameAsync(command.Id, command.Name), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when already exists a country with the same externalCode")]
    public void Should_be_invalid_when_already_exists_a_country_with_the_same_externalCode()
    {
        var command = MakeValidCommand();
        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var country = new Country(command.Name, command.ExternalCode);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(country));
        countryUpdateRepositoryMock.Setup(x => x.ExistsCountryWithExternalCodeAsync(command.Id, command.ExternalCode)).Returns(ValueTask.FromResult(true));

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithNameAsync(command.Id, command.Name), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when does not exist country with id")]
    public void Should_be_invalid_when_does_not_exist_country_with_id()
    {
        var command = MakeValidCommand();
        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult((Country?)null));
        countryUpdateRepositoryMock.Setup(x => x.ExistsCountryWithExternalCodeAsync(command.Id, command.ExternalCode)).Returns(ValueTask.FromResult(true));

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithNameAsync(command.Id, command.Name), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
    }

    [Fact(DisplayName = "Should update the country")]
    public void Should_update_the_country()
    {
        var command = MakeValidCommand();
        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var country = new Country(command.Name, command.ExternalCode);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(country));

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeTrue();
        resultData.Errors.Should().BeEmpty();
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(country), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithNameAsync(command.Id, command.Name), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.Id, command.ExternalCode), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
    }
}
