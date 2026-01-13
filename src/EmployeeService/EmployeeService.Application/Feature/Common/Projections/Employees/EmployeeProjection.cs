namespace EmployeeService.Application.Feature.Common.Projections.Employees;

public class EmployeeProjection
{
    public Ulid PublicId { get; set; }
    public string Code { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }


}