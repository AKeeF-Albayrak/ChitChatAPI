using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities;
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
        private IUserWriteRepository _userWriteRepository;
        private IUserReadRepository _userReadRepository;
        public AddUserCommandHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {

            if(await _userReadRepository.CheckForDuplicateEmailUsernameAsync(request.Email, request.Username))
            {
                return new AddUserCommandResponse
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "This Email or Username Already Exists",
                        ResponseType = Domain.Enums.ResponseType.Conflict,
                    }
                };
            }
            

            var user = new Domain.Entities.User()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                Gender = request.Gender,
                PasswordResetAuthorized = false,
                CreatedDate = DateTime.UtcNow,
                BirhDate = request.BirhDate,
                Name = request.Name,
                Surname = request.Surname,
                Avatar = request.Avatar
            };

            if (request.Avatar == null)
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "BaseProfile.jpg");
                user.Avatar = File.ReadAllBytes(filePath);
            }

            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveChangesAsync();

            return new AddUserCommandResponse()
            {
                Response = new Domain.Dtos.Response.Response
                {
                    Success = true,
                    Message = "User Added Successfully!",
                    ResponseType = Domain.Enums.ResponseType.Success
                }
            };
        }
    }
}
