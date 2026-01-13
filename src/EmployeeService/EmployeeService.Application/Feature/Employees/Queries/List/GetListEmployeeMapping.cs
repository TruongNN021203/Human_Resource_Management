using System.Linq.Expressions;
using EmployeeService.Application.Employees.Queries.List;
using EmployeeService.Domain.Entities;

namespace EmployeeService.Application.Queries.List;

public static class GetListEmployeeMapping
{
    public static Expression<Func<Employee, GetListEmployeeResponse>> Selector() =>
    employee => new GetListEmployeeResponse
    {
        PublicId = employee.PublicId,
        Code = employee.Code,
        FullName = employee.FullName,
        Email = employee.Email,
        DateOfBirth = employee.DateOfBirth,
        CreatedBy = employee.CreatedBy,
        CreatedAt = employee.CreatedAt,
        UpdatedBy = employee.UpdatedBy,
        UpdatedAt = employee.UpdatedAt
    };
}