using Mediator;

namespace EmployeeService.Application.Employees.Commands.Create;

public record CreateEmployeeCommand(
    string Code,
    string FullName,
    string Email,
    DateTime DateOfBirth
) : IRequest<long>;


