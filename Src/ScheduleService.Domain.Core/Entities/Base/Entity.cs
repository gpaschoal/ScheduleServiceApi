namespace ScheduleService.Domain.Core.Entities.Base;

public abstract class Entity : IEquatable<Entity>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;

        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }
}
