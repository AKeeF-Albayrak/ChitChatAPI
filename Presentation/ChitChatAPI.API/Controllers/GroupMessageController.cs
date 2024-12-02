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
        public async Task<IActionResult> GetMessages()
        {
            return Ok();
        }
    }
}
