using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class WorkType : Entity
{
    public string Name { get; private set; } = default!;
    public float Coefficient { get; private set; }

    private WorkType() { }

    public WorkType(string name, float coefficient)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Work type name is required");

        if (coefficient <= 0)
            throw new ArgumentException("Coefficient must be greater than 0");

        Id = IdGenerator.NewId();
        Name = name;
        Coefficient = coefficient;
    }
}
