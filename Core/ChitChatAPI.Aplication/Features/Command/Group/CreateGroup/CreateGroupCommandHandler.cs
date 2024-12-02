using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Aplication.Features.Query.GroupMessage.GetGroupMessages;
using ChitChatAPI.Domain.Entities;
using ChitChatAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Command.Group.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest, CreateGroupCommandResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGroupWriteRepository _groupWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IGroupUserWriteRepository _groupUserWriteRepository;
        public CreateGroupCommandHandler(IHttpContextAccessor httpContextAccessor, IGroupWriteRepository groupWriteRepository, IUserReadRepository userReadRepository, IGroupUserWriteRepository groupUserWriteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _groupWriteRepository = groupWriteRepository;
            _userReadRepository = userReadRepository;
            _groupUserWriteRepository = groupUserWriteRepository;
        }
        public async Task<CreateGroupCommandResponse> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext?.Items["UserId"] is not Guid userId)
            {
                return new CreateGroupCommandResponse
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "Invalid UserId",
                        ResponseType = ResponseType.Unauthorized,
                    }
                };
            }

            Guid groupId = Guid.NewGuid();

            Domain.Entities.Group group = new Domain.Entities.Group
            {
                Id = groupId,
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                CreatedById = userId
            };

            if (request.Image == null)
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "BaseGroup.png");
                group.Image = File.ReadAllBytes(filePath);
            }
            else
            {
                group.Image = request.Image;
            }

            await _groupWriteRepository.AddAsync(group);

            foreach (var id in request.UsersId)
            {
                if(!await _userReadRepository.HasEntityByIdAsync(id))
                {
                    return new CreateGroupCommandResponse
                    {
                        Response = new Domain.Dtos.Response.Response
                        {
                            Success = false,
                            Message = "Invalid UserId",
                            ResponseType = ResponseType.Unauthorized,
                        }
                    };
                }
                GroupUser groupUser = new GroupUser
                {
                    Id = Guid.NewGuid(),
                    GroupId = groupId,
                    Role = Role.Basic,
                    UserId = id,
                };
                await _groupUserWriteRepository.AddAsync(groupUser);
            }

            GroupUser user = new GroupUser
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                GroupId = groupId,
                Role = Role.Admin,
            };

            await _groupUserWriteRepository.AddAsync(user);

            await _groupWriteRepository.SaveChangesAsync();

            return new CreateGroupCommandResponse
            {
                Response = new Domain.Dtos.Response.Response
                {
                    Success = true,
                    Message = "Success",
                    ResponseType = ResponseType.Success,
                }
            };
        }
    }
}
