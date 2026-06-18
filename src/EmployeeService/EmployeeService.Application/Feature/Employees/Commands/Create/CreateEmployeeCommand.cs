using EmployeeService.Domain.Entities;
using Mediator;

namespace EmployeeService.Application.Employees.Commands.Create;

public record CreateEmployeeCommand(
    string Code,
    string FullName,
    string Email,
    DateTime DateOfBirth,
    long SalaryGradeId
) : IRequest<long>;


