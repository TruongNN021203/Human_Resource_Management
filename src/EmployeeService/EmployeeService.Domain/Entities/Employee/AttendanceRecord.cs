using Shared.Kernel.Common;

namespace EmployeeService.Domain.Entities;

public class AttendanceRecord : Entity
{
    public long EmployeeId { get; set; }
    public DateTime WorkDate { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public long WorkTypeId { get; set; }

    protected AttendanceRecord() { }

    public AttendanceRecord(
        long employeeId,
        DateTime workDate,
        DateTime checkIn,
        DateTime checkOut,
        long workTypeId
    )
    {

        Id = IdGenerator.NewId();
        EmployeeId = employeeId;
        WorkDate = workDate;
        WorkTypeId = workTypeId;
        if (checkOut < checkIn)
            throw new ArgumentException("CheckOut must be after CheckIn");

        CheckIn = checkIn;
        CheckOut = checkOut;
    }

}
