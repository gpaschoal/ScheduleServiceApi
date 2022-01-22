using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Enums;

namespace ScheduleService.Infrastructure.Context.Contexts;

public class AuditEntry
{
    public AuditEntry(EntityEntry entry)
    {
        Entry = entry;
        OldValues = new();
        NewValues = new();
        ChangedColumns = new();
    }

    public EntityEntry Entry { get; set; }
    public Guid UserId { get; set; }
    public string TableName { get; set; }
    public Guid PrimaryKey { get; set; }
    public Dictionary<string, object> OldValues { get; set; }
    public Dictionary<string, object> NewValues { get; set; }
    public EAuditType AuditType { get; set; }
    public List<string> ChangedColumns { get; set; }

    public Audit ToAudit()
    {
        var audit = new Audit(UserId, AuditType, TableName, DateTime.Now, JsonConvert.SerializeObject(OldValues), JsonConvert.SerializeObject(NewValues), JsonConvert.SerializeObject(ChangedColumns), PrimaryKey);
        return audit;
    }
}
