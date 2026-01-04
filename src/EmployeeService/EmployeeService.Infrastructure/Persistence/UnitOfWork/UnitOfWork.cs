using EmployeeService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace EmployeeService.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EmployeeDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
        await _transaction?.CommitAsync()!;
    }

    public async Task RollbackAsync()
    {
        await _transaction?.RollbackAsync()!;
    }
}
