using ScheduleService.Domain.Core.Entities.Base;

namespace ScheduleService.Domain.Core.Entities;

public class RolePolicy : EntityAudit
{
    public RolePolicy()
    { }

    public RolePolicy(string policy, Guid roleId)
    {
        Policy = policy;
        RoleId = roleId;
    }

    public string Policy { get; private set; }
    public Guid RoleId { get; private set; }
    public virtual Role? Role { get; }
}
