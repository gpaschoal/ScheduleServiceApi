using Schedule.Service.Domain.Model.Keys;
using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Entities.Base;

public abstract class EntityBase<TKey> : IEquatable<EntityBase<TKey>>
    where TKey : struct, IKey
{
    public TKey Id { get; protected set; }

    public DateTime CreatedAt { get; private set; }
    public UserKey UserCreateId { get; private set; }
    public virtual User? UserCreate { get; }

    public DateTime? UpdatedAt { get; private set; }
    public UserKey? UserLastUpdateId { get; private set; }
    public virtual User? UserLastUpdate { get; }

    public DateTime? DeletedAt { get; private set; }
    public UserKey? UserDeletedId { get; private set; }
    public virtual User? UserDelete { get; }

    public bool Equals(EntityBase<TKey>? other)
    {
        if (other is null)
            return false;

        return Id.Equals(other.Id);
    }
}