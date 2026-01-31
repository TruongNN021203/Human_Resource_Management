using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class EducationLevel : Entity
{
    public string EducationLevelName { get; set; } = default!;
    public EducationLevel(string educationLevelName)
    {
        Id = IdGenerator.NewId();
        EducationLevelName = educationLevelName;
    }
}
