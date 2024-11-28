using ChitChatAPI.Aplication.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.User.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private IUserReadRepository _userReadRepository;
        public AddUserCommandHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
