using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Core.Enums;

namespace ScheduleService.Domain.Core.Entities;

public class Audit : Entity
{
    public Audit(Guid userId, EAuditType type, string tableName, DateTime auditTime, string oldValues, string newValues, string affectedColumns, Guid primaryKey)
    {
        UserId = userId;
        Type = type;
        TableName = tableName;
        AuditTime = auditTime;
        OldValues = oldValues;
        NewValues = newValues;
        AffectedColumns = affectedColumns;
        PrimaryKey = primaryKey;
    }

    public Guid UserId { get; }
    public virtual User User { get; }
    public EAuditType Type { get; }
    public string TableName { get; }
    public DateTime AuditTime { get; }
    public string OldValues { get; }
    public string NewValues { get; }
    public string AffectedColumns { get; }
    public Guid PrimaryKey { get; }
}
