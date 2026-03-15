using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Feature.User.Command.Login
{
    public class AccountLoginResponse
    {
        public string AccessToken { get; set; } = null!;
        public DateTime ExpiredAt { get; set; }
    }
}
