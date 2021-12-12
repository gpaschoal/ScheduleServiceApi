using Schedule.Service.Domain.Model.Keys.Base;

namespace Schedule.Service.Domain.Model.Entities.Base;

public class ActivableEntityBase<TKey> : EntityBase<TKey>, IActivable
    where TKey : struct, IKey
{
    public bool IsActive { get; private set; }

    public DateTime IsActiveChangeDate { get; private set; }

    public void Activate()
    {
        IsActiveChangeDate = DateTime.Now;
        IsActive = true;
    }

    public void Inactivate()
    {
        IsActiveChangeDate = DateTime.Now;
        IsActive = false;
    }
}
