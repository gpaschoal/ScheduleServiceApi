using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.Countries;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.Countries;

public class CountryUpdateHandlerTest
{
    private static CountryUpdateHandler MakeSut(
        ICountryUpdateRepository? countryUpdateRepository = null)
    {
        countryUpdateRepository ??= new Mock<ICountryUpdateRepository>().Object;

        return new CountryUpdateHandler(countryUpdateRepository);
    }

    private static CountryUpdateCommand MakeValidCommand() => new CountryUpdateCommand() { Id = Guid.NewGuid(), Name = "Brazil", ExternalCode = "BR123" };

    [Fact(DisplayName = "Should be invalid when command is invalid and UpdateAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_UpdateAsync_mustnt_not_be_called()
    {
        CountryUpdateCommand command = new() { };

        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithName(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCode(It.IsAny<Guid>(), It.IsAny<string>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when already exists a country with the same name")]
    public void Should_be_invalid_when_already_exists_a_country_with_the_same_name()
    {
        var command = MakeValidCommand();
        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var country = new Country(command.Name, command.ExternalCode);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(country));
        countryUpdateRepositoryMock.Setup(x => x.ExistsCountryWithName(command.Id, command.Name)).Returns(true);

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Name));
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithName(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCode(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);
    }

    [Fact(DisplayName = "Should be invalid when already exists a country with the same externalCode")]
    public void Should_be_invalid_when_already_exists_a_country_with_the_same_externalCode()
    {
        var command = MakeValidCommand();
        Mock<ICountryUpdateRepository> countryUpdateRepositoryMock = new();

        var country = new Country(command.Name, command.ExternalCode);
        countryUpdateRepositoryMock.Setup(x => x.GetByIdAsync(command.Id)).Returns(ValueTask.FromResult(country));
        countryUpdateRepositoryMock.Setup(x => x.ExistsCountryWithExternalCode(command.Id, command.ExternalCode)).Returns(true);

        var sut = MakeSut(countryUpdateRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.ExternalCode));
        countryUpdateRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Country>()), Times.Never);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithName(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);
        countryUpdateRepositoryMock.Verify(x => x.ExistsCountryWithExternalCode(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);
    }
}
