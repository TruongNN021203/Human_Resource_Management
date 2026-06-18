using Mediator;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Feature.User.Command.Login
{
    public record AccountLoginCommand(
        string? Email,
        string? Password,
        string? ClientIp = null) : IRequest<AccountLoginResponse>;
}
