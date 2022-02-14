namespace ScheduleService.Domain.Core.Repositories.Base;

public interface IUnitOfWork
{
    public void BeginTransaction();
    public void CommitTransaction();
    public void RollBackTransaction();
}
