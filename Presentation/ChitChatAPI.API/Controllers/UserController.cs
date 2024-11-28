using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChitChatAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserWriteRepository _userWriteRepository;
        public UserController(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveChangesAsync();
            return Ok(user);
        }
    }
}
