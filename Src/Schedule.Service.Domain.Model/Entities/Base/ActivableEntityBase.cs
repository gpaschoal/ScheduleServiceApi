namespace Schedule.Service.Domain.Model.Entities.Base;

public abstract class ActivableEntityBase : EntityBase, IActivable
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
