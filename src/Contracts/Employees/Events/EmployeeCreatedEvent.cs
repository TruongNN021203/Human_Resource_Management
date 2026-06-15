using Contracts.Common;

namespace Contracts.Employees.Events;

public record EmployeeCreatedEvent : IntegrationEvent
{
    public string EmployeeCode { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; init; }
    public long SalaryGradeId { get; init; }
    public DateTimeOffset JoinDate { get; init; }

    public EmployeeCreatedEvent(
        string employeeCode,
        string fullName,
        string email,
        DateTime dateOfBirth,
        long salaryGradeId,
        DateTimeOffset joinDate)
    {
        EmployeeCode = employeeCode;
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
        SalaryGradeId = salaryGradeId;
        JoinDate = joinDate;
    }
}
