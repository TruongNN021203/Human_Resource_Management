using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class Employee : AggregateRoot
{
    public string Code { get; private set; } = default!;
    public string FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public DateTime DateOfBirth { get; private set; }

    protected Employee() { }

    public Employee(string code, string fullName, string email, DateTime dateOfBirth)
    {
        Id = IdGenerator.NewId();
        Code = code;
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
    }
}
