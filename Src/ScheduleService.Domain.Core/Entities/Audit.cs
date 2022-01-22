using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Core.Enums;

namespace ScheduleService.Domain.Core.Entities;

public class Audit : Entity
{
    public Audit(Guid userId, EAuditType type, string tableName, string oldValues, string newValues, Guid primaryKey)
    {
        UserId = userId;
        PrimaryKey = primaryKey;
        Type = type;
        TableName = tableName;
        AuditTime = DateTime.UtcNow;
        OldValues = oldValues;
        NewValues = newValues;
    }

    public Guid PrimaryKey { get; }
    public Guid UserId { get; }
    public virtual User User { get; }
    public EAuditType Type { get; }
    public string TableName { get; }
    public DateTime AuditTime { get; }
    public string OldValues { get; }
    public string NewValues { get; }
}
