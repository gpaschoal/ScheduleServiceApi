namespace ScheduleService.Domain.Core.Repository;

public interface IUnitOfWork
{
    public void BeginTransaction();
    public void CommitTransaction();
    public void RollBackTransaction();
}
