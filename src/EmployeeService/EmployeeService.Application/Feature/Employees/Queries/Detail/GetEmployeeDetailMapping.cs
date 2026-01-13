using EmployeeService.Application.Employees.Queries.Detail;
using EmployeeService.Application.Employees.Queries.List;

namespace Application.Feature.Employees.Queries.Detail;

public static class GetListEmployeeMapping
{
    public static GetEmployeeDetailResponse ToEmployeeDetailResponse(this GetListEmployeeResponse response) =>
        new GetEmployeeDetailResponse
        {
            PublicId = response.PublicId,
            Code = response.Code,
            FullName = response.FullName,
            Email = response.Email,
            DateOfBirth = response.DateOfBirth,
            CreatedBy = response.CreatedBy,
            CreatedAt = response.CreatedAt,
            UpdatedBy = response.UpdatedBy,
            UpdatedAt = response.UpdatedAt
        };
}