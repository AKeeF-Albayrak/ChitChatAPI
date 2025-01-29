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
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required bool Gender { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateOnly BirhDate { get; set; }
        public byte[]? Avatar { get; set; }
    }
}
