using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class SalaryGrade : Entity
{
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public decimal BaseSalary { get; private set; }
    public ICollection<Employee> Employees { get; private set; } = new List<Employee>();
    private SalaryGrade() { }

    public SalaryGrade(
        string code,
        string name,
        decimal baseSalary
    )
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Salary grade code is required");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Salary grade name is required");

        if (baseSalary <= 0)
            throw new ArgumentException("Base salary must be greater than 0");

        Id = IdGenerator.NewId();
        Code = code;
        Name = name;
        BaseSalary = baseSalary;
    }
}
