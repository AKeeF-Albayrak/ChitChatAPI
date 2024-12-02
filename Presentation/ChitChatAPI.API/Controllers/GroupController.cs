using ChitChatAPI.API.Utilities;
using ChitChatAPI.Aplication.Features.Command.Group.CreateGroup;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChitChatAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IMediator _mediator;
        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateGroup([FromForm]CreateGroupCommandRequest createGroupCommandRequest)
        {
            CreateGroupCommandResponse response = await _mediator.Send(createGroupCommandRequest);
            return ResponseHandler.CreateResponse(response);
        }
    }
}
