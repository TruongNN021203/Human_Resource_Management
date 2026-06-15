using System.Linq.Expressions;
using EmployeeService.Application.Interfaces;
using EmployeeService.Domain.Entities;
using EmployeeService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Infrastructure.Persistence.Repositories;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _dbContext;

    public EmployeeRepository(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> EmailExistsAsync(string email, CancellationToken ct = default)
    {
        return await _dbContext.Employees
            .AnyAsync(x => x.Email == email, ct);
    }

    public async Task AddAsync(Employee employee, CancellationToken ct = default)
    {
        _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<TResult>> ListEmployeeAsync<TResult>(
        Expression<Func<Employee, TResult>> selector,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Employees
            .AsNoTracking()
            .Select(selector)
            .ToListAsync(cancellationToken);
    }

    public async Task<TResult?> GetEmployeeDetailAsync<TResult>(
        long id,
        Expression<Func<Employee, TResult>> selector,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Employees
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);
    }


}
