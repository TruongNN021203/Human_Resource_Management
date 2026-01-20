using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class LaborContract : Entity
{
    public string ContractNumber { get; set; } = default!;
    public long EmployeeId { get; set; }
    public DateTime SignedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Content { get; set; }
    public float SalaryCoefficient { get; set; }

    public LaborContract(
        long employeeId,
        string contractNumber,
        string content,
        DateTime signedDate,
        DateTime startDate,
        DateTime? endDate,
        float salaryCoefficient
    )
    {
        Id = IdGenerator.NewId();
        EmployeeId = employeeId;
        ContractNumber = contractNumber;
        Content = content;
        SignedDate = signedDate;
        if (endDate.HasValue && endDate <= startDate)
            throw new ArgumentException("EndDate must be after StartDate");

        if (salaryCoefficient <= 0)
            throw new ArgumentException("SalaryCoefficient must be greater than 0");

        StartDate = startDate;
        EndDate = endDate;
        SalaryCoefficient = salaryCoefficient;
    }

}
