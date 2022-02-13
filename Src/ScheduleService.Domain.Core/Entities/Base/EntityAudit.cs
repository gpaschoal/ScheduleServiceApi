namespace ScheduleService.Domain.Core.Entities.Base;

public abstract class EntityAudit : Entity
{
    public DateTime CreatedAt { get; set; }
    public Guid UserCreateId { get; set; }
    public virtual User UserCreate { get; }

    public DateTime? UpdatedAt { get; set; }
    public Guid? UserUpdateId { get; set; }
    public virtual User? UserUpdate { get; }

    public DateTime? DeletedAt { get; set; }
    public Guid? UserDeleteId { get; set; }
    public virtual User? UserDelete { get; }
}