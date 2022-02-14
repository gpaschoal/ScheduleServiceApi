﻿using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Countries;
using ScheduleService.Domain.CommandHandler.Commands.Countries;
using ScheduleService.Domain.CommandHandler.Repositories.Countries;
using System;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Countries;

public class CountryDeleteHandlerTest
{
    private static CountryDeleteHandler MakeSut(
        ICountryDeleteRepository countryDeleteRepository = null)
    {
        countryDeleteRepository ??= new Mock<ICountryDeleteRepository>().Object;

        return new(countryDeleteRepository);
    }

    private static CountryDeleteCommand MakeValidCommand() => new() { Id = Guid.NewGuid() };

    [Fact(DisplayName = "Should be invalid when command is invalid and DeleteAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_DeleteAsync_mustnt_not_be_called()
    {
        CountryDeleteCommand command = new() { };

        Mock<ICountryDeleteRepository> countryDeleteRepositoryMock = new();

        var sut = MakeSut(countryDeleteRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));

        countryDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(It.IsAny<Guid>()), Times.Never);
        countryDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByStateAsync(It.IsAny<Guid>()), Times.Never);
        countryDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }

    [Fact(DisplayName = "Should not delete when country does not exist in the DB")]
    public void Should_not_delete_when_country_does_not_exist_in_the_DB()
    {
        CountryDeleteCommand command = MakeValidCommand();

        Mock<ICountryDeleteRepository> countryDeleteRepositoryMock = new();

        countryDeleteRepositoryMock.Setup(x => x.CheckIfExistByIdAsync(command.Id)).ReturnsAsync(false);

        var sut = MakeSut(countryDeleteRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));

        countryDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(command.Id), Times.Once);
        countryDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByStateAsync(command.Id), Times.Once);
        countryDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }

    [Fact(DisplayName = "Should not delete when is used by any state")]
    public void Should_not_delete_when_is_used_by_any_state()
    {
        CountryDeleteCommand command = MakeValidCommand();

        Mock<ICountryDeleteRepository> countryDeleteRepositoryMock = new();
        countryDeleteRepositoryMock.Setup(x => x.CheckIfExistByIdAsync(command.Id)).ReturnsAsync(false);
        countryDeleteRepositoryMock.Setup(x => x.CheckIfIsUsedByStateAsync(command.Id)).ReturnsAsync(true);

        var sut = MakeSut(countryDeleteRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;
        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Should().Contain(x => x.Key != nameof(command.Id));

        countryDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(command.Id), Times.Once);
        countryDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByStateAsync(command.Id), Times.Once);
        countryDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }

    [Fact(DisplayName = "Should delete the country")]
    public void Should_delete_the_country()
    {
        CountryDeleteCommand command = MakeValidCommand();

        Mock<ICountryDeleteRepository> countryDeleteRepositoryMock = new();
        countryDeleteRepositoryMock.Setup(x => x.CheckIfExistByIdAsync(command.Id)).ReturnsAsync(true);

        var sut = MakeSut(countryDeleteRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;
        resultData.IsValid.Should().BeTrue();

        countryDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(command.Id), Times.Once);
        countryDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByStateAsync(command.Id), Times.Once);
        countryDeleteRepositoryMock.Verify(x => x.DeleteAsync(command.Id), Times.Once);
    }
}
