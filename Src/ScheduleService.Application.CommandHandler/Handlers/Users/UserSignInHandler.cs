﻿using ScheduleService.Application.CommandHandler.Services;
using ScheduleService.Application.CommandValidator.Validators.Users;
using ScheduleService.Application.Shared;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.CommandResponses.Users;
using ScheduleService.Domain.Command.Commands.Users;
using ScheduleService.Domain.CommandHandler.Handlers;
using ScheduleService.Domain.CommandHandler.Handlers.Users;
using ScheduleService.Domain.CommandHandler.Repositories.Users;
using ScheduleService.Domain.Core.Entities;

namespace ScheduleService.Application.CommandHandler.Handlers.Users;

internal class UserSignInHandler : CommandHandler<UserSignInCommand, CustomResultData<UserSignInResponse>>, IUserSignInHandler
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

    public override async Task<CustomResultData<UserSignInResponse>> HandleAsync(UserSignInCommand request, CancellationToken cancellationToken)
    {
        if (!Validate<UserSignInValidator>(request))
            return InvalidResponse();

        var encryptedPassword = _encryptionService.Encrypt(request.Password);

        User user = await _repository.GetUserByEmailAndPasswordAsync(email: request.Email, password: encryptedPassword);

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
