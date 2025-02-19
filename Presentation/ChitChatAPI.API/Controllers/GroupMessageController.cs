﻿using ChitChatAPI.API.Utilities;
using ChitChatAPI.Aplication.Features.Query.GroupMessage.GetGroupMessages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChitChatAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupMessageController : ControllerBase
    {
        private IMediator _mediator;
        public GroupMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessages([FromQuery] GetGroupMessagesQueryRequest getGroupMessagesQueryRequest)
        {
            GetGroupMessagesQueryResponse response = await _mediator.Send(getGroupMessagesQueryRequest);
            return ResponseHandler.CreateResponse(response);
        }
    }
}
