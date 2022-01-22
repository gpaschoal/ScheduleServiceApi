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
            .Where(e => e.State == EntityState.Added
                        || e.State == EntityState.Modified
                        || e.State == EntityState.Deleted
                        && e.Entity is not Audit);

        if (!entries.Any())
            return await base.SaveChangesAsync(cancellationToken);

        var currentlyUser = GetUserIdentity();

        if (currentlyUser.Equals(Guid.Empty))
            throw new Exception($"There's no {IdentityConstants.UserIdentifier} Claim");

        OnBeforeSaveChanges(currentlyUser, entries);
        foreach (var entry in entries)
        {
            EntityAudit auditBase = (EntityAudit)entry.Entity;
            DateTime now = DateTime.UtcNow;

            switch (entry.State)
            {
                case EntityState.Added:
                    {
                        auditBase.CreatedAt = now;
                        auditBase.UserCreateId = currentlyUser;
                        Entry(auditBase).Property(p => p.UpdatedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserUpdateId).IsModified = false;
                        Entry(auditBase).Property(p => p.DeletedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserDeleteId).IsModified = false;
                        break;
                    }

                case EntityState.Modified:
                    {
                        auditBase.UpdatedAt = now;
                        auditBase.UserUpdateId = currentlyUser;
                        Entry(auditBase).Property(p => p.CreatedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserCreateId).IsModified = false;
                        Entry(auditBase).Property(p => p.DeletedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserDeleteId).IsModified = false;
                        break;
                    }

                case EntityState.Deleted:
                    {
                        auditBase.DeletedAt = now;
                        auditBase.UserDeleteId = currentlyUser;
                        Entry(auditBase).Property(p => p.CreatedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserCreateId).IsModified = false;
                        Entry(auditBase).Property(p => p.UpdatedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserUpdateId).IsModified = false;
                        Entry(auditBase).State = EntityState.Modified;
                        break;
                    }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSaveChanges(Guid userId, IEnumerable<EntityEntry> entries)
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();
        foreach (var entry in entries)
        {
            var auditEntry = new AuditEntry(entry)
            {
                TableName = entry.Entity.GetType().Name,
                UserId = userId
            };
            auditEntries.Add(auditEntry);
            foreach (var property in entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    auditEntry.PrimaryKey = (Guid)property.CurrentValue;
                    continue;
                }
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.AuditType = EAuditType.Create;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        break;
                    case EntityState.Deleted:
                        auditEntry.AuditType = EAuditType.Delete;
                        break;
                    case EntityState.Modified:
                        if (!property.IsModified)
                            break;

                        if (property?.OriginalValue is null && property?.CurrentValue is null)
                            break;

                        if (property?.OriginalValue?.Equals(property?.CurrentValue) ?? default)
                            break;

                        if (property.OriginalValue is string stringOriValue 
                            && property.CurrentValue is string stringCurValue 
                            && (stringOriValue?.Equals(stringCurValue) ?? default))
                            break;

                        auditEntry.AuditType = EAuditType.Update;

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

                        break;
                }
            }
        }
        foreach (var auditEntry in auditEntries)
        {
            AuditLogs.Add(auditEntry.ToAudit());
        }
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
