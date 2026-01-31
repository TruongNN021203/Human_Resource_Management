using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class Department : AggregateRoot
{
    public string? Code { get; private set; }
    public string DepartmentName { get; private set; } = default!;
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public string? Note { get; private set; }
    public long? ParentId { get; private set; }

    private Department() { }

    public Department(
        string departmentName,
        string? code = null,
        string? address = null,
        string? note = null,
        long? parentId = null
    )
    {
        if (string.IsNullOrWhiteSpace(departmentName))
            throw new ArgumentException("Department name is required");

        Id = IdGenerator.NewId();
        DepartmentName = departmentName;
        Code = code;
        Address = address;
        Note = note;
        ParentId = parentId;
    }
}
