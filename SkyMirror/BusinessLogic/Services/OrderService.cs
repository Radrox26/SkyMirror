using SkyMirror.BusinessLogic.Dto.Order;
using SkyMirror.BusinessLogic.Interfaces;
using SkyMirror.DataAccess.Interfaces;
using SkyMirror.Entities;
using System.Security.Cryptography;

namespace SkyMirror.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(o => new OrderResponseDto(
                o.OrderId,
                o.UserId,
                o.TotalAmount,
                o.Status,
                o.OrderDate,
                o.OrderItems.Select(oi => new OrderItemResponseDto(
                    oi.OrderItemId,
                    oi.OrderId,
                    oi.ProductId,
                    oi.Quantity,
                    oi.Price
                )).ToList()
            ));
        }

        public async Task<OrderResponseDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return null;

            return new OrderResponseDto(
                order.OrderId,
                order.UserId,
                order.TotalAmount,
                order.Status,
                order.OrderDate,
                order.OrderItems.Select(oi => new OrderItemResponseDto(
                    oi.OrderItemId,
                    oi.OrderId,
                    oi.ProductId,
                    oi.Quantity,
                    oi.Price
                )).ToList()
            );
        }

        public async Task<int> CreateOrderAsync(CreateOrderRequestDto request)
        {
            // 🔸 Compute total amount from order items
            decimal computedTotal = request.OrderItems.Sum(item => item.Quantity * item.Price);

            // 🔹 Create Order entity and assign navigation collection
            var order = new Order
            {
                UserId = request.UserId,
                TotalAmount = computedTotal,
                Status = request.Status
            };

            foreach (var item in request.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            // 🔹 Save the order (along with its OrderItems) through repository
            return await _orderRepository.AddAsync(order);
        }



        public async Task UpdateOrderAsync(int id, UpdateOrderRequestDto request)
        {
            var existing = await _orderRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Order not found");

            existing.TotalAmount = request.TotalAmount;
            existing.Status = request.Status;

            await _orderRepository.UpdateAsync(existing);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
