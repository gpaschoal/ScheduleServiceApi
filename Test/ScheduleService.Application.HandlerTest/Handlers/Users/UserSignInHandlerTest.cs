using FluentAssertions;
using Moq;
using ScheduleService.Application.Handler.Handlers.Users;
using ScheduleService.Application.Handler.Services;
using ScheduleService.Application.Handler.Services.Responses;
using ScheduleService.Domain.Command.Commands.Users;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Repositories.Users;
using System;
using System.Linq;
using Xunit;

namespace ScheduleService.Application.HandlerTest.Handlers.Users;

public class UserSignInHandlerTest
{
    private static UserSignInHandler MakeSut(
      IUserSignInRepository? userRepository = null,
      IEncryptionService? encryptionService = null,
      ITokenService? tokenService = null)
    {
        userRepository ??= new Mock<IUserSignInRepository>().Object;
        encryptionService ??= new Mock<IEncryptionService>().Object;
        tokenService ??= new Mock<ITokenService>().Object;

        return new UserSignInHandler(userRepository, encryptionService, tokenService);
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

    [Fact(DisplayName = "Should be invalid when dont find the user")]
    public void Should_be_invalid_when_dont_find_the_user()
    {
        var command = MakeValidCommand();
        Mock<IUserSignInRepository> userRepositoryMock = new();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        User user = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        userRepositoryMock.Setup(x => x.GetUserByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>()))
#pragma warning disable CS8604 // Possible null reference argument.
                    .Returns(user);
#pragma warning restore CS8604 // Possible null reference argument.

        var sut = MakeSut(userRepository: userRepositoryMock.Object);

        var resultData = sut.Handle(command, cancellationToken: System.Threading.CancellationToken.None).Result;

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
        userRepositoryMock.Setup(x => x.GetUserByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

        UserSignInHandler sut = MakeSut(userRepository: userRepositoryMock.Object,
                          encryptionService: encryptionServiceMock.Object,
                          tokenService: tokenServiceMock.Object);

        _ = sut.Handle(command, cancellationToken: System.Threading.CancellationToken.None).Result;

        userRepositoryMock.Verify(x => x.GetUserByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        userRepositoryMock.Verify(x => x.GetUserByEmailAndPassword(
                                                It.Is<string>(x => x.Equals(command.Email)),
                                                It.Is<string>(x => x.Equals(encryptedPassword)))
        );

        tokenServiceMock.Verify(x => x.TokenGenerator(It.IsAny<User>()), Times.Once);
        tokenServiceMock.Verify(x => x.TokenGenerator(It.Is<User>(x => x.Equals(user))));
    }
}
