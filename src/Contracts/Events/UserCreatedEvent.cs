using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public record UserCreatedEvent(
        string Code,
     string FullName,
     string Email,
     DateTime DateOfBirth,
     long SalaryGradeId);
}
