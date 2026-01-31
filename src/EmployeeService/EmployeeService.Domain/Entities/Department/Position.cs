using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class Position : Entity
{
    public string PositionName { get; set; } = default!;
    public string? Description { get; set; }
    public int Level { get; set; }
    public Position(string positionName, string description, int level)
    {
        Id = IdGenerator.NewId();
        PositionName = positionName;
        Description = description;
        Level = level;
    }

}
