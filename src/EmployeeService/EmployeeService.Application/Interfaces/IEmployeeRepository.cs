using System.Linq.Expressions;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
    Task AddAsync(Employee employee, CancellationToken ct = default);

    Task<IReadOnlyList<TResult>> ListEmployeeAsync<TResult>(
        Expression<Func<Employee, TResult>> selector,
        CancellationToken cancellationToken
    );

    Task<TResult?> GetEmployeeDetailAsync<TResult>(
        long id,
        Expression<Func<Employee, TResult>> selector,
        CancellationToken cancellationToken
    );
}
