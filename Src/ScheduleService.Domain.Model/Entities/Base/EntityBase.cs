namespace ScheduleService.Domain.Model.Entities.Base;

public abstract class EntityBase : IEquatable<EntityBase>
{
  public EntityBase()
  {
    Id = Guid.NewGuid();
  }

  public Guid Id { get; private set; }

  public DateTime CreatedAt { get; private set; }
  public Guid UserCreateId { get; private set; }
  public virtual User UserCreate { get; }

  public DateTime? UpdatedAt { get; private set; }
  public Guid? UserLastUpdateId { get; private set; }
  public virtual User? UserLastUpdate { get; }

  public DateTime? DeletedAt { get; private set; }
  public Guid? UserDeletedId { get; private set; }
  public virtual User? UserDelete { get; }

  public bool Equals(EntityBase? other)
  {
    if (other is null)
      return false;

    return Id.Equals(other.Id);
  }

  public override bool Equals(object? obj)
  {
    return Equals(obj as EntityBase);
  }
}