using ChitChatAPI.API.Utilities;
using ChitChatAPI.Aplication.Features.Command.User.AddUser;
using ChitChatAPI.Aplication.Features.Command.User.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChitChatAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return ResponseHandler.CreateResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] AddUserCommandRequest addUserCommandRequest)
        {
            AddUserCommandResponse response = await _mediator.Send(addUserCommandRequest);
            return ResponseHandler.CreateResponse(response);
        }
    }
}
