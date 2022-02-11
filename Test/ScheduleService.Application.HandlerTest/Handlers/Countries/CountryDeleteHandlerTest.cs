using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Handler.Repositories.Countries;
using System;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.Countries;

public class CountryDeleteHandlerTest
{
    private static CountryDeleteHandler MakeSut(
        ICountryDeleteRepository? countryDeleteRepository = null)
    {
        countryDeleteRepository ??= new Mock<ICountryDeleteRepository>().Object;

        return new CountryDeleteHandler(countryDeleteRepository);
    }

    private static CountryDeleteCommand MakeValidCommand() => new CountryDeleteCommand() { Id = Guid.NewGuid() };

    [Fact(DisplayName = "Should be invalid when command is invalid and DeleteAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_DeleteAsync_mustnt_not_be_called()
    {
        CountryDeleteCommand command = new() { };

        Mock<ICountryDeleteRepository> countryDeleteRepositoryMock = new();

        var sut = MakeSut(countryDeleteRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));

        countryDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(It.IsAny<Guid>()), Times.Never);
        countryDeleteRepositoryMock.Verify(x => x.CheckIfIsUsedByState(It.IsAny<Guid>()), Times.Never);
        countryDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }
}
