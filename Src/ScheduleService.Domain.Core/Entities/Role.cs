using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Core.Entities;

public class Role : ActivableEntityBase
{
    public Role()
    { }

    public Role(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public virtual ICollection<UserRole>? UserRoles { get; }
    public virtual ICollection<RolePolicy>? RolePolicies { get; }
}
