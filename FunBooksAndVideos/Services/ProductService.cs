using AutoMapper;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repositories.Interfaces;
using FunBooksAndVideos.Services.Interfaces;

namespace FunBooksAndVideos.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            ILogger<ProductService> logger,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetAllProducts)} - retrieving items");

            var users = await _productRepository.GeProducts();
            var mappedUsers = _mapper.Map<List<ProductModel>>(users);

            _logger.LogInformation(new EventId(2), $"{nameof(GetAllProducts)} - items retrieved");

            return mappedUsers;
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(GetProductById)} - retrieving item by id {productId}");

            var user = await _productRepository.GetProductById(productId);
            var mappedUser = _mapper.Map<ProductModel>(user);

            _logger.LogInformation(new EventId(4), $"{nameof(GetProductById)} - item retrieved");

            return mappedUser;
        }
    }
}
