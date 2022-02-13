using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Core.Entities;

public class UserRole : ActivableEntityBase
{
    public UserRole()
    { }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public Guid UserId { get; private set; }
    public virtual User? User { get; }
    public Guid RoleId { get; private set; }
    public virtual Role? Role { get; }
}
