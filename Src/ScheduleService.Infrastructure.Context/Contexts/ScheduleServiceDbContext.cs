using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ScheduleService.Domain.Model.Entities.Base;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleServiceDbContext).Assembly);
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added
                        || e.State == EntityState.Modified
                        || e.State == EntityState.Deleted);

        if (!entries.Any())
            return await base.SaveChangesAsync(cancellationToken);

        var currentlyUser = GetUserIdentity();

        if (currentlyUser == Guid.Empty)
            throw new Exception($"There's no {IdentityConstants.UserIdentifier} Claim");

        foreach (var entityEntry in entries)
        {
            var auditBase = (EntityBase)entityEntry.Entity;

            switch (entityEntry.State)
            {
                case EntityState.Added:
                    {
                        auditBase.SetValue(x => x.CreatedAt, DateTime.UtcNow);
                        auditBase.SetValue(x => x.UserCreateId, currentlyUser);
                        break;
                    }

                case EntityState.Modified:
                    {
                        auditBase.SetValue(x => x.UpdatedAt, DateTime.UtcNow);
                        auditBase.SetValue(x => x.UserUpdateId, currentlyUser);
                        Entry(auditBase).Property(p => p.CreatedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserCreateId).IsModified = false;
                        break;
                    }

                case EntityState.Deleted:
                    {
                        entityEntry.State = EntityState.Unchanged;
                        auditBase.SetValue(x => x.DeletedAt, DateTime.UtcNow);
                        auditBase.SetValue(x => x.UserDeleteId, currentlyUser);
                        Entry(auditBase).Property(p => p.CreatedAt).IsModified = false;
                        Entry(auditBase).Property(p => p.UserCreateId).IsModified = false;
                        break;
                    }
            }

            auditBase.SetValue(x => x.UpdatedAt, DateTime.UtcNow);
            auditBase.SetValue(x => x.UserUpdateId, currentlyUser);
        }

        return await base.SaveChangesAsync(cancellationToken);
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
