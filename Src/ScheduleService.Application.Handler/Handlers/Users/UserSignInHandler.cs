using ScheduleService.Application.Command.Commands.User;
using ScheduleService.Application.Handler.Repositories.Users;
using ScheduleService.Application.Handler.Services;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.ViewModelResponses.Responses.User;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.Handler.Handlers.Users;

public class UserSignInHandler : HandlerBase<UserSignInCommand, CustomResultData<UserSignInResponse>>
{
    private readonly IUserSignInRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly ITokenService _tokenService;

    public UserSignInHandler(
        IHandlerBus handlerBus,
        IUserSignInRepository repository,
        IEncryptionService encryptionService,
        ITokenService tokenService) : base(handlerBus)
    {
        _repository = repository;
        _encryptionService = encryptionService;
        _tokenService = tokenService;
    }

    public override Task<CustomResultData<UserSignInResponse>> HandleExecution(UserSignInCommand request, CancellationToken cancellationToken)
    {
        var encryptedPassword = _encryptionService.Encrypt(request.Password);

        User user = _repository.GetUserByEmailAndPassword(email: request.Email, password: encryptedPassword);

        if (user is null)
            AddError(nameof(request.Password), ValidationResource.UserNotFound);

        if (IsInvalid)
            return InvalidResponse();

        var tokenResponse = _tokenService.TokenGenerator(user);

        UserSignInResponse loginResponse = new()
        {
            Email = user.Email.Trim(),
            FullName = user.FullName.Trim(),
            CreatedAt = DateTime.Now,
            Token = tokenResponse.Token,
            ExpireAt = tokenResponse.ExpirationDate
        };

        CustomResultData<UserSignInResponse> response = new(loginResponse);

        return ValidResponse(response);
    }
}
