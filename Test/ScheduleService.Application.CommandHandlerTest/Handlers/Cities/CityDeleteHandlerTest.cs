using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Cities;
using ScheduleService.Domain.Command.Commands.Cities;
using ScheduleService.Domain.CommandHandler.Repositories.Cities;
using System;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Cities;

public class CityDeleteHandlerTest
{
    private static CityDeleteHandler MakeSut(
        ICityDeleteRepository? cityDeleteRepository = null)
    {
        cityDeleteRepository ??= new Mock<ICityDeleteRepository>().Object;

        return new(cityDeleteRepository);
    }

    private static CityDeleteCommand MakeValidCommand() => new() { Id = Guid.NewGuid() };

    [Fact(DisplayName = "Should be invalid when command is invalid and DeleteAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_DeleteAsync_mustnt_not_be_called()
    {
        CityDeleteCommand command = new() { };

        Mock<ICityDeleteRepository> cityDeleteRepositoryMock = new();

        var sut = MakeSut(cityDeleteRepositoryMock.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Id));

        cityDeleteRepositoryMock.Verify(x => x.CheckIfExistByIdAsync(It.IsAny<Guid>()), Times.Never);
        cityDeleteRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);
    }
}
