using AutoMapper;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repositories.Interfaces;
using FunBooksAndVideos.Services.Interfaces;

namespace FunBooksAndVideos.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(
            ILogger<OrderService> logger,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderModel>> GetAllOrders()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetAllOrders)} - retrieving items");

            var orders = await _orderRepository.GetOrders();
            var mappedOrders = _mapper.Map<List<OrderModel>>(orders);

            _logger.LogInformation(new EventId(2), $"{nameof(GetAllOrders)} - items retrieved");

            return mappedOrders;
        }

        public async Task<OrderModel> GetOrderById(int orderId)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(GetOrderById)} - retrieving item by id {orderId}");

            var order = await _orderRepository.GetOrderById(orderId);
            var mappedOrder = _mapper.Map<OrderModel>(order);

            _logger.LogInformation(new EventId(4), $"{nameof(GetOrderById)} - item retrieved");

            return mappedOrder;
        }
    }
}
