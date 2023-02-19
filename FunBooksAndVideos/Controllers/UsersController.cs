using FunBooksAndVideos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetUsers();

            return Ok(users);
        }
    }
}