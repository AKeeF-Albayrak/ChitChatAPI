using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.User.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public required string IpAdress { get; set; }
        public required string DeviceInfo { get; set; }
        public required string UsernameOrEmail { get; set; }
        public required string Password { get; set; }
    }
}
