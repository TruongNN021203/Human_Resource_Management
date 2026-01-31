using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class Allowance : Entity
{
    public long EmployeeId { get; private set; }
    public string Name { get; private set; } = default!;
    public decimal Amount { get; private set; }
    public DateTime ReceivedDate { get; private set; }

    protected Allowance() { }

    public Allowance(
        long employeeId,
        string name,
        decimal amount,
        DateTime receivedDate
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Allowance name is required");

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0");

        Id = IdGenerator.NewId();
        EmployeeId = employeeId;
        Name = name;
        Amount = amount;
        ReceivedDate = receivedDate;
    }

    public void UpdateAmount(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than 0");

        Amount = amount;
    }
}
