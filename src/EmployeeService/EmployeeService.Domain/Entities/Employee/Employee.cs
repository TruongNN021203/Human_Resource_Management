using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class Employee : AggregateRoot
{
    public string EmployeeCode { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? IdentityNumber { get; set; }
    public long? DepartmentId { get; set; }
    public long? PositionId { get; set; }
    public long? EducationLevelId { get; set; }
    public long SalaryGradeId { get; set; }
    public string? AvatarUrl { get; set; }
    public string Status { get; set; } = "Active";
    public long? IdentityUserId { get; set; }
    public SalaryGrade SalaryGrade { get; set; }
    public Employee(
    string employeeCode,
    string fullName,
    string email,
    DateTime dateOfBirth,
    string? gender = null,
    string? phone = null,
    string? identityNumber = null
)
    {
        Id = IdGenerator.NewId();
        EmployeeCode = employeeCode;
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Phone = phone;
        IdentityNumber = identityNumber;
        Status = "Active";
    }
    public void AssignSalaryGrade(SalaryGrade salaryGrade)
    {
        SalaryGrade = salaryGrade ?? throw new ArgumentNullException(nameof(salaryGrade));
        SalaryGradeId = salaryGrade.Id;
    }
}