using FunBooksAndVideos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(
            ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        
        [HttpGet]
        [Route("/getallproducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(Get)} - retrieving items");

            try
            {
                var users = await _productService.GetAllProducts();

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