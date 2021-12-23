namespace ScheduleService.Domain.Core.Entities.Base;

public interface IActivable
{
    bool IsActive { get; }
    DateTime IsActiveChangeDate { get; }

    public void Activate();
    public void Inactivate();
}
