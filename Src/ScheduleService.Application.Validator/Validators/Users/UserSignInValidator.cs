using FluentValidation;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Users;

namespace ScheduleService.Application.Validator.Validators.Users;

public class UserSignInValidator : AbstractValidator<UserSignInCommand>
{
    public UserSignInValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationResource.IsRequired);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationResource.IsRequired);
    }
}
