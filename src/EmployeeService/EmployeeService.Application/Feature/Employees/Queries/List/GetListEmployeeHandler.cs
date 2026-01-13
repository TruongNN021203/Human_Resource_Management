using EmployeeService.Application.Employees.Queries.List;
using EmployeeService.Application.Interfaces;
using Mediator;

namespace EmployeeService.Application.Queries.List;

public sealed class GetListEmployeeHandler
    : IRequestHandler<GetListEmployeeQuery, IReadOnlyList<GetListEmployeeResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetListEmployeeHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async ValueTask<IReadOnlyList<GetListEmployeeResponse>> Handle(
        GetListEmployeeQuery query,
        CancellationToken cancellationToken)
    {
        return await _employeeRepository.ListEmployeeAsync(
            GetListEmployeeMapping.Selector(),
            cancellationToken
        );
    }
}
