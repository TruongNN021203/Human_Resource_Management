using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class Insurance : Entity
{
    public long EmployeeId { get; set; }
    public string InsuranceNumber { get; set; } = default!;
    public DateTime IssuedDate { get; set; }
    public string? IssuedPlace { get; set; }
    public string? RegisteredHospital { get; set; }

    public Insurance(
        long employeeId,
        string insuranceNumber,
        DateTime issuedDate, 
        string issuedPlace, 
        string registeredHospital
    )
    {
        Id = IdGenerator.NewId();
        EmployeeId = employeeId;
        InsuranceNumber = insuranceNumber;
        IssuedPlace = issuedPlace;
        RegisteredHospital = registeredHospital;
        IssuedDate = issuedDate;
    }
}
