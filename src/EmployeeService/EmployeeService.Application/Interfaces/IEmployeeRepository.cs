using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
    Task AddAsync(Employee employee, CancellationToken ct = default);
}
