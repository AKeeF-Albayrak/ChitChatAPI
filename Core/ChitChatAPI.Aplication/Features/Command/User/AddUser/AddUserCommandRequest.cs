using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.User.AddUser
{
    public class AddUserCommandRequest : IRequest<AddUserCommandResponse>
    {
    }
}
