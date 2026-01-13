using EmployeeService.Application.Employees.Queries.List;
using Mediator;

namespace EmployeeService.Application.Queries.List;

public record GetListEmployeeQuery()
    : IRequest<IReadOnlyList<GetListEmployeeResponse>>;
