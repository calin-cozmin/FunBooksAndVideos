using FunBooksAndVideos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    [ApiController]
    [Route("user")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(
            ILogger<UsersController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        
        [HttpGet]
        [Route("/getallusers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(Get)} - retrieving items");

            try
            {
                var users = await _userService.GetAllUsers();

                _logger.LogInformation(new EventId(2), $"{nameof(Get)} - items retried");

                return Ok(users);
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(3),e, $"{nameof(Get)} - an error has occurred");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}