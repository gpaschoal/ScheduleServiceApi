using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.CommandHandler.Commands.Countries;
using ScheduleService.Domain.CommandHandler.Repositories.Countries;
using ScheduleService.Domain.Core.Entities;
using System.Linq;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Countries;

public class CountryCreateHandlerTest
{
    private static CountryCreateHandler MakeSut(
        ICountryCreateRepository countryCreateRepository = null)
    {
        countryCreateRepository ??= new Mock<ICountryCreateRepository>().Object;

        return new CountryCreateHandler(countryCreateRepository);
    }

    private static CountryCreateCommand MakeValidCommand() => new() { Name = "Brazil", ExternalCode = "BR123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and AddAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_AddAsync_mustnt_not_be_called()
    {
        CountryCreateCommand command = new() { };

        Mock<ICountryCreateRepository> countryCreateRepositoryMock = new();

        var sut = MakeSut(countryCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithName(It.IsAny<string>()), Times.Never);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(It.IsAny<string>()), Times.Never);
        countryCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Country>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a country with the same name")]
    public void Should_be_invalid_when_already_exists_a_country_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<ICountryCreateRepository> countryCreateRepositoryMock = new();

        countryCreateRepositoryMock.Setup(x => x.ExistsCountryWithName(command.Name)).ReturnsAsync(true);

        var sut = MakeSut(countryCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Name));
        countryCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Country>()), Times.Never);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithName(command.Name), Times.Once);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.ExternalCode), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when already exists a country with the same externalCode")]
    public void Should_be_invalid_when_already_exists_a_country_with_the_same_externalCode()
    {
        var command = MakeValidCommand();
        Mock<ICountryCreateRepository> countryCreateRepositoryMock = new();

        countryCreateRepositoryMock.Setup(x => x.ExistsCountryWithExternalCodeAsync(command.ExternalCode)).ReturnsAsync(true);

        var sut = MakeSut(countryCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        countryCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Country>()), Times.Never);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithName(command.Name), Times.Once);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.ExternalCode), Times.Once);
    }

    [Fact(DisplayName = "Should add a country")]
    public void Should_add_a_country()
    {
        var command = MakeValidCommand();
        Mock<ICountryCreateRepository> countryCreateRepositoryMock = new();

        var sut = MakeSut(countryCreateRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeTrue();
        resultData.Errors.Should().BeEmpty();
        countryCreateRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Country>()), Times.Once);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithName(command.Name), Times.Once);
        countryCreateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCodeAsync(command.ExternalCode), Times.Once);
    }
}
