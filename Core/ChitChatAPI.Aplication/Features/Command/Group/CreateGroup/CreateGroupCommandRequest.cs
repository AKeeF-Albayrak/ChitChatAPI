using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.Group.CreateGroup
{
    public class CreateGroupCommandRequest : IRequest<CreateGroupCommandResponse>
    {
        public required string Name { get; set; }
        public byte[] Image { get; set; }
        public required string Description { get; set; }
        public ICollection<Guid> UsersId { get; set; }
    }
}
