using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Query.GroupMessage.GetGroupMessages
{
    public class GetGroupMessagesQueryHandler : IRequestHandler<GetGroupMessagesQueryRequest, GetGroupMessagesQueryResponse>
    {
        private readonly IGroupMessageReadRepository _groupMessageReadRepository;
        private readonly IGroupUserReadRepository _groupUserReadRepository;
        private readonly IGroupReadRepository _groupReadRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetGroupMessagesQueryHandler(IGroupMessageReadRepository groupMessageReadRepository, IHttpContextAccessor httpContextAccessor, IGroupReadRepository groupReadRepository, IGroupUserReadRepository groupUserReadRepository)
        {
            _groupMessageReadRepository = groupMessageReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _groupReadRepository = groupReadRepository;
            _groupUserReadRepository = groupUserReadRepository;
        }
        public async Task<GetGroupMessagesQueryResponse> Handle(GetGroupMessagesQueryRequest request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext?.Items["UserId"] is not Guid userId)
            {
                return new GetGroupMessagesQueryResponse
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "Invalid UserId",
                        ResponseType = ResponseType.Unauthorized,
                    }
                };
            }

            if (!await _groupReadRepository.HasEntityByIdAsync(request.GroupId))
            {
                return new GetGroupMessagesQueryResponse
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "Invalid Group",
                        ResponseType = ResponseType.NotFound,
                    }
                };
            }

            if(!await _groupUserReadRepository.CheckGroupUserByUserId(userId, request.GroupId))
            {
                return new GetGroupMessagesQueryResponse
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "Unauthorized!",
                        ResponseType = ResponseType.Unauthorized,
                    }
                };
            }
            
            var messages = await _groupMessageReadRepository.GetMessagesByGroupIdAsync(request.GroupId);
            return new GetGroupMessagesQueryResponse
            {
                Response = new Domain.Dtos.Response.Response
                {
                    Success = true,
                    Message = "Success",
                    ResponseType = ResponseType.Success,
                },
                Messages = messages
            };
        }
    }
}
