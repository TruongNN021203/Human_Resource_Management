using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Feature.User.Command.CreateAccount
{
    public record CreateEmployeeCommand(
     string Code,
     string FullName,
     string Email,
     DateTime DateOfBirth,
     long SalaryGradeId
 ) : IRequest<long>;



}
