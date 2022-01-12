using EasyValidation.Core;
using EasyValidation.Core.Extensions;
using ScheduleService.Application.Shared.Resources;
using ScheduleService.Domain.Command.Commands.Users;

namespace ScheduleService.Application.Validator.Validators.Users;

public class UserSignInValidator : Validation<UserSignInCommand>
{
    public override void Validate()
    {
        ForMember(x => x.Email)
            .IsRequired(ValidationResource.IsRequired)
            .IsNotNullOrWhiteSpace(ValidationResource.IsRequired);
        ForMember(x => x.Password)
            .IsRequired(ValidationResource.IsRequired)
            .IsNotNullOrWhiteSpace(ValidationResource.IsRequired);
    }
}
