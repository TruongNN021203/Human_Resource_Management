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
        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync(ct);
    }
}
