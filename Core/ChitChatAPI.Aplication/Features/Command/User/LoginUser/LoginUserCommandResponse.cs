using ChitChatAPI.Domain.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.User.LoginUser
{
    public class LoginUserCommandResponse
    {
        public Response Response { get; set; }
        public string Token { get; set; }
    }
}
