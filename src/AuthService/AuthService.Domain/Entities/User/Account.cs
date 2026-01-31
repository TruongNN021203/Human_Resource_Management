using Shared.Kernel.Common;

namespace AuthService.Domain.Entities;
public class Account: AggregateRoot
{
    public string EmployeeCode { get; private set; } = default!;
    public string FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string? Password { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string? Gender { get; private set; }
    public string? Phone { get; private set; }
    public string? IdentityNumber { get; private set; }
    public long? DepartmentId { get; private set; }
    public long? PositionId { get; private set; }
    public long? EducationLevelId { get; private set; }
    public long SalaryGradeId { get; private set; }
    public string? AvatarUrl { get; private set; }
    public string Status { get; private set; } = "Active";
     
     
    public Account(
    string employeeCode,
    string fullName,
    string email,
    string password,
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
        Password=password;
        IdentityNumber = identityNumber;
        Status = "Active";
    }
     
}