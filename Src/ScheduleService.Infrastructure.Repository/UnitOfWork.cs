﻿using Microsoft.EntityFrameworkCore.Storage;
using ScheduleService.Domain.Repository;
using ScheduleService.Infrastructure.Context.Contexts;

namespace ScheduleService.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ScheduleServiceDbContext _context;

    private IDbContextTransaction? _transaction;

    public UnitOfWork(ScheduleServiceDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _ = _context.SaveChangesAsync().Result;
        _transaction?.Commit();
    }

    public void RollBackTransaction()
    {
        _transaction?.Rollback();
    }
}
