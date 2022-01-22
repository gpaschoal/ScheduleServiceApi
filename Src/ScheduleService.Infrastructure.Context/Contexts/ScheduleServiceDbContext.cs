using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScheduleService.Domain.Core.Entities;
using ScheduleService.Domain.Core.Entities.Base;
using ScheduleService.Domain.Core.Enums;
using ScheduleService.Domain.Shared.Constants;
using System.Security.Claims;

namespace ScheduleService.Infrastructure.Context.Contexts;

public class ScheduleServiceDbContext : DbContext
{
    private static readonly string[] IgnoreColumns = new string[]
        { "Id", "CreatedAt", "UserCreateId", "UserCreate", "UpdatedAt", "UserUpdateId", "UserUpdate", "DeletedAt", "UserDeleteId", "UserDelete" };

    private readonly IHttpContextAccessor _httpContextAccessor;

    public ScheduleServiceDbContext(DbContextOptions options,
        IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected DbSet<Audit> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleServiceDbContext).Assembly);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted
                        && e.Entity is not Audit)
            .ToArray();

        if (!entries.Any())
            return await base.SaveChangesAsync(cancellationToken);

        var currentlyUserId = GetUserIdentity();

        if (currentlyUserId.Equals(Guid.Empty))
            throw new Exception($"There's no {IdentityConstants.UserIdentifier} Claim");

        foreach (var entry in entries)
        {
            var auditEntry = new AuditEntryHelper(entry)
            {
                TableName = entry.Entity.GetType().Name,
                UserId = currentlyUserId,
                PrimaryKey = (Guid)entry.Properties.Single(x => x.Metadata.IsPrimaryKey()).CurrentValue
            };
            EntityAudit auditBase = (EntityAudit)entry.Entity;
            DateTime utcNow = DateTime.UtcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    EntryAdded(currentlyUserId, entry, auditEntry, auditBase, utcNow);
                    break;
                case EntityState.Modified:
                    EntryModified(currentlyUserId, entry, auditEntry, auditBase, utcNow);
                    break;
                case EntityState.Deleted:
                    EntryDeleted(currentlyUserId, auditEntry, auditBase, utcNow);
                    break;
            }

            if (!auditEntry.AuditType.Equals(EAuditType.Unchanged))
                AuditLogs.Add(auditEntry.ToAudit());
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    private void EntryAdded(Guid currentlyUser, EntityEntry entry, AuditEntryHelper auditEntry, EntityAudit auditBase, DateTime now)
    {
        auditBase.CreatedAt = now;
        auditBase.UserCreateId = currentlyUser;
        Entry(auditBase).Property(p => p.UpdatedAt).IsModified = false;
        Entry(auditBase).Property(p => p.UserUpdateId).IsModified = false;
        Entry(auditBase).Property(p => p.DeletedAt).IsModified = false;
        Entry(auditBase).Property(p => p.UserDeleteId).IsModified = false;

        auditEntry.AuditType = EAuditType.Create;

        var filteredProperties = entry.Properties.Where(x => !IgnoreColumns.Contains(x.Metadata.Name) && x.CurrentValue is not null);
        foreach (var filteredProperty in filteredProperties)
            auditEntry.NewValues[filteredProperty.Metadata.Name] = filteredProperty.CurrentValue;
    }

    private void EntryModified(Guid currentlyUser, EntityEntry entry, AuditEntryHelper auditEntry, EntityAudit auditBase, DateTime now)
    {
        auditBase.UpdatedAt = now;
        auditBase.UserUpdateId = currentlyUser;
        Entry(auditBase).Property(p => p.CreatedAt).IsModified = false;
        Entry(auditBase).Property(p => p.UserCreateId).IsModified = false;
        Entry(auditBase).Property(p => p.DeletedAt).IsModified = false;
        Entry(auditBase).Property(p => p.UserDeleteId).IsModified = false;

        auditEntry.AuditType = EAuditType.Modified;

        var filteredPropertiesEntry = entry.Properties
                                        .Where(x => !IgnoreColumns.Contains(x.Metadata.Name) && x.IsModified
                                                    && !(x?.OriginalValue is null && x?.CurrentValue is null));
        foreach (PropertyEntry property in filteredPropertiesEntry)
        {
            if (property?.OriginalValue is null && property?.CurrentValue is null)
                continue;

            if (property?.OriginalValue?.Equals(property?.CurrentValue) ?? default)
            {
                property.IsModified = false;
                continue;
            }

            if (property.OriginalValue is string stringOriValue
                && property.CurrentValue is string stringCurValue
                && (stringOriValue?.Trim().Equals(stringCurValue?.Trim()) ?? default))
            {
                property.IsModified = false;
                continue;
            }

            string propertyName = property.Metadata.Name;

            if (property.OriginalValue is string)
            {
                auditEntry.OldValues[propertyName] = ((string?)property.OriginalValue)?.Trim();
                auditEntry.NewValues[propertyName] = property.CurrentValue;
            }
            else
            {
                auditEntry.OldValues[propertyName] = property.OriginalValue;
                auditEntry.NewValues[propertyName] = property.CurrentValue;
            }
        }

        if (!auditEntry.NewValues.Any())
        {
            auditEntry.AuditType = EAuditType.Unchanged;
            entry.State = EntityState.Unchanged;
        }
    }

    private void EntryDeleted(Guid currentlyUser, AuditEntryHelper auditEntry, EntityAudit auditBase, DateTime now)
    {
        auditBase.DeletedAt = now;
        auditBase.UserDeleteId = currentlyUser;
        Entry(auditBase).Property(p => p.CreatedAt).IsModified = false;
        Entry(auditBase).Property(p => p.UserCreateId).IsModified = false;
        Entry(auditBase).Property(p => p.UpdatedAt).IsModified = false;
        Entry(auditBase).Property(p => p.UserUpdateId).IsModified = false;
        Entry(auditBase).State = EntityState.Modified;

        auditEntry.AuditType = EAuditType.Delete;
    }

    private Guid GetUserIdentity()
    {
        var user = _httpContextAccessor.HttpContext.User;

        var identity = (ClaimsIdentity?)user.Identity;

        var claims = identity?.Claims;

        var userIdClaim = claims?.SingleOrDefault(x => x.Type == IdentityConstants.UserIdentifier);

        return string.IsNullOrWhiteSpace(userIdClaim?.Value)
                ? Guid.Empty
                : Guid.Parse(userIdClaim.Value);
    }
}
