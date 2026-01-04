using Mediator;

namespace EmployeeService.Application.Commands;

public record CreateEmployeeCommand(
    string Code,
    string FullName,
    string Email,
    DateTime DateOfBirth
) : IRequest<long>;


