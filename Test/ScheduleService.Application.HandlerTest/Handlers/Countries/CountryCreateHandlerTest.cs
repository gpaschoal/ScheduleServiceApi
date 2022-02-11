using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.Countries;
using ScheduleService.Domain.Command.Commands.Countries;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.Countries;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.Countries;

public class CountryCreateHandlerTest
{
    private static CountryCreateHandler MakeSut(
        ICountryCreateRepository? countryCreateRepository = null)
    {
        countryCreateRepository ??= new Mock<ICountryCreateRepository>().Object;

        return new CountryCreateHandler(countryCreateRepository);
    }



    [Fact(DisplayName = "Should be invalid when command is invalid and AddAsync mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_AddAsync_mustnt_not_be_called()
    {
        CountryCreateCommand command = new() { Name = null, ExternalCode = null };

        Mock<ICountryCreateRepository> countryCreateRepository = new();

        var sut = MakeSut(countryCreateRepository.Object);

        var resultData = sut.Handle(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Name));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.ExternalCode));

        countryCreateRepository.Verify(x => x.AddAsync(It.IsAny<Country>()), Times.Never);
    }
}
