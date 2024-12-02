using ChitChatAPI.Aplication.Abstractions.Repositories;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetGroupMessagesQueryHandler(IGroupMessageReadRepository groupMessageReadRepository, IHttpContextAccessor httpContextAccessor)
        {
            _groupMessageReadRepository = groupMessageReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<GetGroupMessagesQueryResponse> Handle(GetGroupMessagesQueryRequest request, CancellationToken cancellationToken)
        {
            
            var messages = await _groupMessageReadRepository.GetMessagesByGroupIdAsync(request.GroupId);
            return new GetGroupMessagesQueryResponse
            {
                Response = new Domain.Dtos.Response.Response
                {
                    Success = true,
                    Message = "Success",
                    ResponseType = Domain.Enums.ResponseType.Success,
                }
            };
        }
    }
}
