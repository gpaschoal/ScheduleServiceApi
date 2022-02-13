using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Enums;

namespace ScheduleService.Infrastructure.Context.Contexts;

public class AuditEntryHelper
{
    public AuditEntryHelper(EntityEntry entry)
    {
        Entry = entry;
        OldValues = new();
        NewValues = new();
    }

    public EntityEntry Entry { get; set; }
    public Guid UserId { get; set; }
    public string TableName { get; set; }
    public Guid PrimaryKey { get; set; }
    public Dictionary<string, object> OldValues { get; set; }
    public Dictionary<string, object> NewValues { get; set; }
    public EAuditType AuditType { get; set; }

    public Audit ToAudit()
    {
        var audit = new Audit(UserId, AuditType, TableName, JsonConvert.SerializeObject(OldValues), JsonConvert.SerializeObject(NewValues), PrimaryKey);
        return audit;
    }
}
