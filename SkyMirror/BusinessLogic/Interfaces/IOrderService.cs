using SkyMirror.BusinessLogic.Dto.Order;

namespace SkyMirror.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
        Task<OrderResponseDto?> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOrderRequestDto request);
        Task UpdateOrderAsync(int id, UpdateOrderRequestDto request);
        Task DeleteOrderAsync(int id);
    }
}
