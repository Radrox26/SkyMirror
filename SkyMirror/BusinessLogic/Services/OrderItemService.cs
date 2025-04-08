using SkyMirror.BusinessLogic.Dto.OrderItem;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;

namespace SkyMirror.BusinessLogic.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderItemResponseDto>> GetAllAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();

            List<OrderItemResponseDto> response = new List<OrderItemResponseDto>();

            foreach(var orderItem in orderItems)
            {
                response.Add(new OrderItemResponseDto(orderItem.OrderItemId, orderItem.OrderId, orderItem.ProductId, orderItem.Quantity, orderItem.Price));
            }

            return response;
        }

        public async Task<OrderItemResponseDto?> GetByIdAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Order item not found");

            return new OrderItemResponseDto(orderItem.OrderItemId, orderItem.OrderId, orderItem.ProductId, orderItem.Quantity, orderItem.Price);
        }

        public async Task<int> CreateAsync(CreateOrderItemRequestDto request)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId)
                ?? throw new KeyNotFoundException("Order not found");

            var orderItem = new OrderItem
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = request.Price
            };

            return await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateAsync(int id, UpdateOrderItemRequestDto request)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Order item not found");

            orderItem.ProductId = request.ProductId;
            orderItem.Quantity = request.Quantity;
            orderItem.Price = request.Price;

            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Order item not found");

            await _orderItemRepository.DeleteAsync(orderItem.OrderId);
        }
    }
}
