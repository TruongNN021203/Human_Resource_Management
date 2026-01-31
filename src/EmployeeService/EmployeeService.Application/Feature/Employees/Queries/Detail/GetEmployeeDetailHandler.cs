using Contracts.ApiWrapper;
using EmployeeService.Application.Employees.Queries.Detail;
using EmployeeService.Application.Interfaces;
using Mediator;

namespace Application.Feature.Employees.Queries.Detail;

public sealed class GetEmployeeDetailQueryHandler
    : IRequestHandler<GetEmployeeDetailQuery, Result<GetEmployeeDetailResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeDetailQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async ValueTask<Result<GetEmployeeDetailResponse>> Handle(
        GetEmployeeDetailQuery request,
        CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeDetailAsync(
      request.EmployeeId,
      e => new GetEmployeeDetailResponse
      {
          PublicId = e.PublicId,
          Code = e.EmployeeCode,
          FullName = e.FullName,
          Email = e.Email,
          DateOfBirth = e.DateOfBirth,
          CreatedBy = e.CreatedBy,
          CreatedAt = e.CreatedAt,
          UpdatedBy = e.UpdatedBy,
          UpdatedAt = e.UpdatedAt
      },
      cancellationToken);

        if (employee is null)
        {
            return Result<GetEmployeeDetailResponse>
                .NotFound($"Employee {request.EmployeeId} not found");
        }


        return Result<GetEmployeeDetailResponse>.Ok(employee);



    }
}
