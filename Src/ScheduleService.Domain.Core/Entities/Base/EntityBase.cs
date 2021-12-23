﻿namespace ScheduleService.Domain.Core.Entities.Base;

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
    public Guid? UserUpdateId { get; private set; }
    public virtual User? UserUpdate { get; }

    public DateTime? DeletedAt { get; private set; }
    public Guid? UserDeleteId { get; private set; }
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