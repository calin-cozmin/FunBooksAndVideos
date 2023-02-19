using FunBooksAndVideos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        
        [HttpGet]
        [Route("/getallorders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(Get)} - retrieving items");

            try
            {
                var users = await _orderService.GetAllOrders();

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