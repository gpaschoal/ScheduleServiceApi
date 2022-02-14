using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.CommandHandler.Commands.Users;

namespace ScheduleService.Application.CommandHandler.Validators.Users;

public class UserSignInValidator : AbstractValidator<UserSignInCommand>
{
    public UserSignInValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
