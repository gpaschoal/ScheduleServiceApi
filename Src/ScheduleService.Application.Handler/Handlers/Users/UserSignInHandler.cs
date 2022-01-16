using ScheduleService.Application.Handler.Services;
using ScheduleService.Application.Response.Responses.Users;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Application.Validator.Validators.Users;
using ScheduleService.Domain.Command.Commands.Users;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Handler.Handlers;
using ScheduleService.Domain.Handler.Handlers.Users;
using ScheduleService.Domain.Handler.Repositories.Users;

namespace ScheduleService.Application.Handler.Handlers.Users;

internal class UserSignInHandler : RequestHandler<UserSignInCommand, CustomResultData<UserSignInResponse>>, IUserSignInHandler
{
    private readonly IUserSignInRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly ITokenService _tokenService;

    public UserSignInHandler(
        IUserSignInRepository repository,
        IEncryptionService encryptionService,
        ITokenService tokenService)
    {
        _repository = repository;
        _encryptionService = encryptionService;
        _tokenService = tokenService;
    }

    public override Task<CustomResultData<UserSignInResponse>> Handle(UserSignInCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<UserSignInValidator>(request))
            return InvalidResponseAsync();

        var encryptedPassword = _encryptionService.Encrypt(request.Password);

        User user = _repository.GetUserByEmailAndPassword(email: request.Email, password: encryptedPassword);

        if (user is null)
            AddError(nameof(request.Password), ValidationResource.UserNotFound);

        if (IsInvalid)
            return InvalidResponseAsync();

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

        return ValidResponseAsync(response);
    }
}
