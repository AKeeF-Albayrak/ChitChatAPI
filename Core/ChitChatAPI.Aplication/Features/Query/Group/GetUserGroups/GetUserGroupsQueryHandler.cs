using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Aplication.Features.Query.GroupMessage.GetGroupMessages;
using ChitChatAPI.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Query.Group.GetUserGroups
{
    public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQueryRequest, GetUserGroupsQueryResponse>
    {
        private readonly IGroupReadRepository _groupReadRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetUserGroupsQueryHandler(IGroupReadRepository groupReadRepository, IHttpContextAccessor httpContextAccessor)
        {
            _groupReadRepository = groupReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<GetUserGroupsQueryResponse> Handle(GetUserGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext?.Items["UserId"] is not Guid userId)
            {
                return new GetUserGroupsQueryResponse
                {
                    Response = new Domain.Dtos.Response.Response
                    {
                        Success = false,
                        Message = "Invalid UserId",
                        ResponseType = ResponseType.Unauthorized,
                    }
                };
            }

            var groups = await _groupReadRepository.GetUserGroupsAsync(userId);

            return new GetUserGroupsQueryResponse
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
