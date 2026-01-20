
using EmployeeService.Domain.Enums;
using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class RewardDisciplinary : Entity
{
    public long EmployeeId { get; set; }
    public RewardDisciplinaryType Type { get; set; }
    public string? DecisionNumber { get; set; }
    public string? Content { get; set; }
    public DateTime EffectiveDate { get; set; }
    public RewardDisciplinary(
        long employeeId,
        RewardDisciplinaryType type,
        DateTime effectiveDate,
        string? decisionNumber,
        string? content
    )
    {
        Id = IdGenerator.NewId();
        EmployeeId = employeeId;
        Type = type;
        EffectiveDate = effectiveDate;
        DecisionNumber = decisionNumber;
        Content = content;
    }
}
