using FluentAssertions;
using Moq;
using ScheduleService.Application.CommandHandler.Handlers.Users;
using ScheduleService.Application.CommandHandler.Services;
using ScheduleService.Application.CommandHandler.Services.Responses;
using ScheduleService.Domain.CommandHandler.Commands.Users;
using ScheduleService.Domain.CommandHandler.Repositories.Users;
using ScheduleService.Domain.Core.Entities;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace ScheduleService.Application.CommandHandlerTest.Handlers.Users;

public class UserSignInHandlerTest
{
    private static UserSignInHandler MakeSut(
      IUserSignInRepository userRepository = null,
      IEncryptionService encryptionService = null,
      ITokenService tokenService = null)
    {
        userRepository ??= new Mock<IUserSignInRepository>().Object;
        encryptionService ??= new Mock<IEncryptionService>().Object;
        tokenService ??= new Mock<ITokenService>().Object;

        return new(userRepository, encryptionService, tokenService);
    }

    private static User MakeUser()
    {
        User user = new(
            firstName: "Jeremy",
            lastName: "Authryst",
            userName: "JereAuth",
            password: "validPassword",
            email: "gustav@mail.com",
            cpf: new("00000000011"),
            cityId: null,
            telephone1: new(codeArea: 11, phoneNumber: 011111111),
            telephone2: new(codeArea: 11, phoneNumber: 011111111),
            cellphone1: new(codeArea: 11, phoneNumber: 911111111),
            cellphone2: new(codeArea: 11, phoneNumber: 911111111),
            address: new(Street: "street", Neighborhood: "neighborhood", LocalReference: "loclaref", ZipCode: "zipcode", Number: "number"));
        return user;
    }

    private static UserSignInCommand MakeValidCommand() => new() { Email = "mail@valid.com", Password = "valid_password" };

    [Fact(DisplayName = "Should be invalid when command is invalid and GetUserByEmailAndPassword mustn't not be called")]
    public void Should_be_invalid_when_command_is_invalid_and_GetUserByEmailAndPassword_mustnt_not_be_called()
    {
        UserSignInCommand command = new();

        Mock<IUserSignInRepository> userRepositoryMock = new();

        var sut = MakeSut(userRepository: userRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();

        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Email));
        resultData.Errors.Should().Contain(x => x.Key == nameof(command.Password));

        userRepositoryMock.Verify(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact(DisplayName = "Should be invalid when dont find the user")]
    public void Should_be_invalid_when_dont_find_the_user()
    {
        var command = MakeValidCommand();
        Mock<IUserSignInRepository> userRepositoryMock = new();
        var user = (User)null;
        userRepositoryMock.Setup(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(user);

        var sut = MakeSut(userRepository: userRepositoryMock.Object);

        var resultData = sut.HandleAsync(command, CancellationToken.None).Result;

        resultData.IsValid.Should().BeFalse();
        resultData.Errors.Single().Key.Should().Be(nameof(command.Password));
    }

    [Fact(DisplayName = "Should GetUserByEmailAndPassword be called with the email and the encrypted password and TokenGenerator with the user got")]
    public void Should_GetUserByEmailAndPassword_be_called_with_the_email_and_the_encrypted_password_and_TokenGenerator_with_the_user_got()
    {
        UserSignInCommand command = MakeValidCommand();
        string encryptedPassword = "encryptedPassword";
        Mock<IEncryptionService> encryptionServiceMock = new();
        encryptionServiceMock.Setup(x => x.Encrypt(It.IsAny<string>())).Returns(encryptedPassword);

        TokenResponse tokenResponse = new() { ExpirationDate = DateTime.Now, Token = "validToken" };
        Mock<ITokenService> tokenServiceMock = new();
        tokenServiceMock.Setup(x => x.TokenGenerator(It.IsAny<User>())).Returns(tokenResponse);

        User user = MakeUser();
        Mock<IUserSignInRepository> userRepositoryMock = new();
        userRepositoryMock.Setup(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);

        UserSignInHandler sut = MakeSut(userRepository: userRepositoryMock.Object,
                          encryptionService: encryptionServiceMock.Object,
                          tokenService: tokenServiceMock.Object);

        _ = sut.HandleAsync(command, CancellationToken.None).Result;

        userRepositoryMock.Verify(x => x.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        userRepositoryMock.Verify(x => x.GetUserByEmailAndPasswordAsync(
                                                It.Is<string>(x => x.Equals(command.Email)),
                                                It.Is<string>(x => x.Equals(encryptedPassword)))
        );

        tokenServiceMock.Verify(x => x.TokenGenerator(It.IsAny<User>()), Times.Once);
        tokenServiceMock.Verify(x => x.TokenGenerator(It.Is<User>(x => x.Equals(user))));
    }
}
